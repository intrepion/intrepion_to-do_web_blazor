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

        var toDoListList = await context.ToDoLists.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var toDoList = toDoListList.FirstOrDefault(x =>
                true
                && x.NormalizedTitle == record.ToDoList_NormalizedTitle
            );

            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var toDoItem = new ToDoItem
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    IsCompleted = record.IsCompleted,
                    Ordering = record.Ordering,
                    ToDoList = toDoList,
                    Title = record.Title,
                    NormalizedTitle = record.Title.ToUpper(CultureInfo.InvariantCulture),
                    // NewEntityCodePlaceholder
                };

                var dbToDoItem = await context.ToDoItems.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedTitle == toDoItem.NormalizedTitle
                    // CompositeKeyCodePlaceholder
                );

                if (dbToDoItem is null)
                {
                    await context.ToDoItems.AddAsync(toDoItem);
                }
                else
                {
                    dbToDoItem.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbToDoItem.IsCompleted = record.IsCompleted;
                    dbToDoItem.Ordering = record.Ordering;
                    dbToDoItem.ToDoList = toDoList;
                    dbToDoItem.Title = record.Title;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
