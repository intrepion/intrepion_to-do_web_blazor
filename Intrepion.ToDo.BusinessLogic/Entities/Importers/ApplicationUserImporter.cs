﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class ApplicationUserImporter
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

        if (context.Users is null)
        {
            Console.WriteLine("Database table not found: context.Users");
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

        var records = csv.GetRecords<ApplicationUserRecord>();

        foreach (var record in records)
        {
            var applicationUser = new ApplicationUser
            {
                ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                Email = record.Email,
                NormalizedEmail = record.Email.ToUpper(CultureInfo.InvariantCulture),
                NormalizedUserName = record.UserName.ToUpper(CultureInfo.InvariantCulture),
                PhoneNumber = record.PhoneNumber,
                UserName = record.UserName,
            };

            var dbApplicationUser = await context.Users.SingleAsync(
                x => true
                && x.NormalizedUserName != null
                && x.NormalizedUserName == applicationUser.NormalizedUserName
            );

            if (dbApplicationUser is null)
            {
                await context.Users.AddAsync(applicationUser);
            }
            else
            {
                dbApplicationUser.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                dbApplicationUser.Email = record.Email;
                dbApplicationUser.NormalizedEmail = record.Email.ToUpper(CultureInfo.InvariantCulture);
                dbApplicationUser.NormalizedUserName = record.UserName.ToUpper(CultureInfo.InvariantCulture);
                dbApplicationUser.PhoneNumber = record.PhoneNumber;
            }
        }

        await context.SaveChangesAsync();
    }
}
