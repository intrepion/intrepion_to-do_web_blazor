using System.Globalization;
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

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                && applicationUser is not null
                && toDoList is not null
                && toDoList is not null
                // NullCheckCodePlaceholder
            )
            {
                var toDoItem = new ToDoItem
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    // NewEntityCodePlaceholder
                };

                var dbToDoItem = await context.ToDoItems.SingleOrDefaultAsync(
                    x => true
                    && x.ApplicationUser.Equals(applicationUser)
                    && x.NormalizedTitle.Equals(toDoItem.NormalizedTitle)
                    && x.DueDateTime.Equals(toDoItem.DueDateTime)
                    && x.ToDoList.ApplicationUser.Equals(toDoList.ApplicationUser)
                    && x.ToDoList.Equals(toDoList)
                    // CompositeKeyCodePlaceholder
                );

                if (dbToDoItem is null)
                {
                    await context.ToDoItems.AddAsync(toDoItem);
                }
                else
                {
                    dbToDoItem.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
