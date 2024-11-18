﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class ApplicationRoleImporter
{
    public static async Task ImportAsync(
       ApplicationDbContext context,
       string userName, string csvPath
    )
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("File not found: " + csvPath);
            return;
        }

        if (context.Roles is null)
        {
            Console.WriteLine("Database table not found: context.Roles");
            return;
        }

        var normalizedUserName = userName.ToUpperInvariant();
        var applicationUserUpdatedBy = await context.Users.SingleOrDefaultAsync(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(normalizedUserName));

        if (applicationUserUpdatedBy is null)
        {
            Console.WriteLine("UserName not found: " + userName);
            return;
        }

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture)
        });

        var records = csv.GetRecords<ApplicationRoleRecord>();

        foreach (var record in records)
        {
            var applicationRole = new ApplicationRole
            {
                ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                Name = record.Name,
                NormalizedName = record.Name.ToUpper(CultureInfo.InvariantCulture),
            };

            var dbApplicationRole = await context.Roles.SingleAsync(
                x => true
                && x.NormalizedName != null
                && x.NormalizedName == applicationRole.NormalizedName
            );

            if (dbApplicationRole is null)
            {
                await context.Roles.AddAsync(applicationRole);
            }
            else
            {
                dbApplicationRole.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
            }
        }

        await context.SaveChangesAsync();
    }
}
