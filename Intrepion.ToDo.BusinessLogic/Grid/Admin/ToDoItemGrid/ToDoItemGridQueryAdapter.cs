using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoItemGrid;

public class ToDoItemGridQueryAdapter
{
    private readonly IToDoItemFilters controls;

    private readonly Dictionary<ToDoItemFilterColumns, Expression<Func<ToDoItem, string>>> expressions =
        new()
        {
            { ToDoItemFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { ToDoItemFilterColumns.DueDateTime, x => x != null ? x.DueDateTime.ToString() : string.Empty },
            { ToDoItemFilterColumns.IsCompleted, x => x != null ? x.IsCompleted.ToString() : string.Empty },
            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<ToDoItemFilterColumns, Func<IQueryable<ToDoItem>, IQueryable<ToDoItem>>> filterQueries = [];

    public ToDoItemGridQueryAdapter(IToDoItemFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { ToDoItemFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<ToDoItem>> FetchAsync(IQueryable<ToDoItem> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<ToDoItem> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<ToDoItem> FetchPageQuery(IQueryable<ToDoItem> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<ToDoItem> FilterAndQuery(IQueryable<ToDoItem> root)
    {
        var sb = new System.Text.StringBuilder();

        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
