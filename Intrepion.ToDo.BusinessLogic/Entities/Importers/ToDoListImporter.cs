using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.ToDo.BusinessLogic.Data;
using Intrepion.ToDo.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Entities.Importers;

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
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture),
            Delimiter = "|",
        });

        var records = csv.GetRecords<ToDoListRecord>();

        var applicationUserList = await context.Users.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var applicationUser = applicationUserList.FirstOrDefault(x =>
                true
                && x.NormalizedUserName.Equals(record.ApplicationUser_NormalizedUserName)
            );

            // ManyToOneCodePlaceholder

            if (true
                && applicationUser is not null
            // NullCheckCodePlaceholder
            )
            {
                var toDoList = new ToDoList
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    ApplicationUser = applicationUser,
                    DueDateTime = record.DueDateTime,
                    Title = record.Title,
                    NormalizedTitle = record.Title.ToUpper(CultureInfo.InvariantCulture),
                    // NewEntityCodePlaceholder
                };

                var dbToDoList = await context.ToDoLists.SingleOrDefaultAsync(
                    x => true
                    && x.ApplicationUser.Equals(applicationUser)
                    && x.NormalizedTitle.Equals(toDoList.NormalizedTitle)
                    && x.DueDateTime.Equals(toDoList.DueDateTime)
                    // CompositeKeyCodePlaceholder
                );

                if (dbToDoList is null)
                {
                    await context.ToDoLists.AddAsync(toDoList);
                }
                else
                {
                    dbToDoList.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbToDoList.ApplicationUser = applicationUser;
                    dbToDoList.DueDateTime = record.DueDateTime;
                    dbToDoList.Title = record.Title;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
