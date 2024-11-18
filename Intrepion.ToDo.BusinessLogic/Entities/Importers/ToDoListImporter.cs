﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class ToDoListImporter
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

        if (context.ToDoLists is null)
        {
            Console.WriteLine("Database table not found: context.ToDoLists");
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

        var records = csv.GetRecords<ToDoListRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var toDoList = new ToDoList
            {
                ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                Title = record.Title,
                // NewEntityCodePlaceholder
            };

            var dbToDoList = await context.ToDoLists.SingleOrDefaultAsync(
                x => true
                && x.NormalizedTitle == toDoList.NormalizedTitle
                // CompositeKeyCodePlaceholder
            );

            if (dbToDoList is null)
            {
                await context.ToDoLists.AddAsync(toDoList);
            }
            else
            {
                dbToDoList.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
            }
        }

        await context.SaveChangesAsync();
    }
}
