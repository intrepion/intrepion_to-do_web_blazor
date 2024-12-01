using System.Diagnostics;
using System.Linq.Expressions;
using Intrepion.ToDo.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoListGrid;

public class ToDoListGridQueryAdapter
{
    private readonly IToDoListFilters controls;

    private readonly Dictionary<ToDoListFilterColumns, Expression<Func<ToDoList, string>>> expressions =
        new()
        {
            { ToDoListFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { ToDoListFilterColumns.DueDateTime, x => x != null ? x.DueDateTime.ToString() : string.Empty },
            { ToDoListFilterColumns.Title, x => x != null && x.Title != null ? x.Title : string.Empty },
            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<ToDoListFilterColumns, Func<IQueryable<ToDoList>, IQueryable<ToDoList>>> filterQueries = [];

    public ToDoListGridQueryAdapter(IToDoListFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { ToDoListFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<ToDoList>> FetchAsync(IQueryable<ToDoList> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<ToDoList> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<ToDoList> FetchPageQuery(IQueryable<ToDoList> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<ToDoList> FilterAndQuery(IQueryable<ToDoList> root)
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
