using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoItemGrid;

// Creates the correct expressions to filter and sort.
public class ToDoItemGridQueryAdapter
{
    // Holds state of the grid.
    private readonly IToDoItemFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<ToDoItemFilterColumns, Expression<Func<ToDoItem, string>>> expressions =
        new()
        {
            { ToDoItemFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { ToDoItemFilterColumns.IsCompleted, x => x != null ? x.IsCompleted.ToString() : string.Empty },
            { ToDoItemFilterColumns.Ordering, x => x != null ? x.Ordering.ToString() : string.Empty },
            // SortExpressionCodePlaceholder
        };

    // Queryables for filtering.
    private readonly Dictionary<ToDoItemFilterColumns, Func<IQueryable<ToDoItem>, IQueryable<ToDoItem>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The IToDoItemFilters" to use.
    public ToDoItemGridQueryAdapter(IToDoItemFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { ToDoItemFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{ToDoItem} to work from.
    // Returns the resulting ICollection{ToDoItem}.
    public async Task<ICollection<ToDoItem>> FetchAsync(IQueryable<ToDoItem> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{ToDoItem} to use.
    public async Task CountAsync(IQueryable<ToDoItem> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{ToDoItem} to modify.
    // Returns the new IQueryable{ToDoItem} for a page.
    public IQueryable<ToDoItem> FetchPageQuery(IQueryable<ToDoItem> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{ToDoItem} to start with.
    // Returns the resulting IQueryable{ToDoItem} with sorts and filters applied.
    private IQueryable<ToDoItem> FilterAndQuery(IQueryable<ToDoItem> root)
    {
        var sb = new System.Text.StringBuilder();

        // Apply a filter?
        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        // Apply the expression.
        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        // Return the unfiltered query for total count, and the filtered for fetching.
        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
