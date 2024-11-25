﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class ToDoItemImporter
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

        if (context.ToDoItems is null)
        {
            Console.WriteLine("Database table not found: context.ToDoItems");
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
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture),
            Delimiter = "|",
        });

        var records = csv.GetRecords<ToDoItemRecord>();

        var applicationUserList = await context.Users.ToListAsync();
        var toDoListList = await context.ToDoLists.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var applicationUser = applicationUserList.FirstOrDefault(x =>
                true
                && x.NormalizedUserName.Equals(record.ApplicationUser_NormalizedUserName)
            );

            var toDoList = toDoListList.FirstOrDefault(x =>
                true
                && x.ApplicationUser.NormalizedUserName.Equals(record.ToDoList_ApplicationUser_NormalizedUserName)
                && x.NormalizedTitle.Equals(record.ToDoList_NormalizedTitle)
                && x.CreateDateTime.Equals(record.ToDoList_CreateDateTime)
            );

            // ManyToOneCodePlaceholder

            if (true
                && applicationUser is not null
                && toDoList is not null
                // NullCheckCodePlaceholder
            )
            {
                var toDoItem = new ToDoItem
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    ApplicationUser = applicationUser,
                    CreateDateTime = record.CreateDateTime,
                    IsCompleted = record.IsCompleted,
                    Ordering = record.Ordering,
                    ToDoList = toDoList,
                    Title = record.Title,
                    // NewEntityCodePlaceholder
                };

                var dbToDoItem = await context.ToDoItems.SingleOrDefaultAsync(
                    x => true
                    && x.ApplicationUser.Equals(applicationUser)
                    && x.ToDoList.Equals(toDoList)
                    && x.NormalizedTitle.Equals(toDoItem.NormalizedTitle)
                    && x.CreateDateTime.Equals(toDoItem.CreateDateTime)
                    // CompositeKeyCodePlaceholder
                );

                if (dbToDoItem is null)
                {
                    await context.ToDoItems.AddAsync(toDoItem);
                }
                else
                {
                    dbToDoItem.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbToDoItem.ApplicationUser = applicationUser;
                    dbToDoItem.CreateDateTime = record.CreateDateTime;
                    dbToDoItem.IsCompleted = record.IsCompleted;
                    dbToDoItem.Ordering = record.Ordering;
                    dbToDoItem.ToDoList = toDoList;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
