using System.Diagnostics;
using System.Linq.Expressions;
using Intrepion.ToDo.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoListGrid;

// Creates the correct expressions to filter and sort.
public class ToDoListGridQueryAdapter
{
    // Holds state of the grid.
    private readonly IToDoListFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<ToDoListFilterColumns, Expression<Func<ToDoList, string>>> expressions =
        new()
        {
            { ToDoListFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { ToDoListFilterColumns.Title, x => x != null && x.Title != null ? x.Title : string.Empty },
            // SortExpressionCodePlaceholder
        };

    // Queryables for filtering.
    private readonly Dictionary<ToDoListFilterColumns, Func<IQueryable<ToDoList>, IQueryable<ToDoList>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The IToDoListFilters" to use.
    public ToDoListGridQueryAdapter(IToDoListFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { ToDoListFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{ToDoList} to work from.
    // Returns the resulting ICollection{ToDoList}.
    public async Task<ICollection<ToDoList>> FetchAsync(IQueryable<ToDoList> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{ToDoList} to use.
    public async Task CountAsync(IQueryable<ToDoList> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{ToDoList} to modify.
    // Returns the new IQueryable{ToDoList} for a page.
    public IQueryable<ToDoList> FetchPageQuery(IQueryable<ToDoList> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{ToDoList} to start with.
    // Returns the resulting IQueryable{ToDoList} with sorts and filters applied.
    private IQueryable<ToDoList> FilterAndQuery(IQueryable<ToDoList> root)
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
