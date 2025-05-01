using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace Intrepion.ToDo.Shared.Grid;

public partial class InfoGrid
{
    [Parameter]
    public List<string> ColumnNames { get; set; } = [];
    [Parameter]
    public List<ColumnType> ColumnTypes { get; set; } = [];
    [Parameter]
    public List<string?> Filters { get; set; } = [];
    [Parameter]
    public List<Guid>? Ids { get; set; } = [];
    [Parameter]
    public List<List<string>>? Info { get; set; } = [];
    [Parameter]
    public EventCallback<int> OnPageChanged { get; set; }
    [Parameter]
    public EventCallback<int> OnRowsPerPage { get; set; }
    [Parameter]
    public EventCallback<List<(int, bool)>> OnSortsChanged { get; set; }
    [Parameter]
    public int Page { get; set; } = 1;
    private int previousRowsPerPage;
    [Parameter]
    public int RowsPerPage { get; set; } = 10;
    [Parameter]
    public List<(int, bool)> Sorts { get; set; } = [];
    [Parameter]
    public int TotalPages { get; set; } = 0;
    [Parameter]
    public int TotalRows { get; set; } = 0;
    [Parameter]
    public string UrlName { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        previousRowsPerPage = RowsPerPage;
    }

    protected override void OnParametersSet()
    {
        if (ColumnNames.Count > 0 && Filters.Count == 0)
        {
            Filters = [.. Enumerable.Repeat<string?>(null, ColumnNames.Count)];
        }

        if (previousRowsPerPage != RowsPerPage)
        {
            previousRowsPerPage = RowsPerPage;
        }
    }

    public void SetFilter(int column, string? filter)
    {
        if (column < 0)
        {
            return;
        }

        if (column >= ColumnTypes.Count)
        {
            return;
        }

        Filters[column] = filter;
    }

    public async Task NextPage()
    {
        var nextPage = Page + 1;

        if (nextPage <= TotalPages)
        {
            await OnPageChanged.InvokeAsync(nextPage);
        }
    }

    public async Task PreviousPage()
    {
        var previousPage = Page - 1;

        if (previousPage >= 1)
        {
            await OnPageChanged.InvokeAsync(previousPage);
        }
    }

    public async Task SetRowsPerPage(int rowsPerPage)
    {
        previousRowsPerPage = rowsPerPage;
        RowsPerPage = rowsPerPage;
        await OnRowsPerPage.InvokeAsync(rowsPerPage);
    }

    public async Task SetSort(int column)
    {
        Console.WriteLine($"SetSort method called with column {column}");
        
        if (column < 0 || column >= ColumnTypes.Count)
        {
            Console.WriteLine("Column index out of range");
            return;
        }

        var found = -1;
        var n = Sorts.Count;

        // Find if this column is already in the sorts list
        for (var i = 0; i < n; i++)
        {
            if (Sorts[i].Item1 == column)
            {
                found = i;
                break;
            }
        }

        var newSorts = new List<(int, bool)>(Sorts);
        
        Console.WriteLine($"Current sorts: {string.Join(", ", Sorts.Select(s => $"{s.Item1}:{s.Item2}"))}");
        Console.WriteLine($"Found column at index: {found}");

        if (found == -1)
        {
            // First click: Add column to the beginning of the sort list (ascending)
            newSorts.Insert(0, (column, true));
            Console.WriteLine($"Added column {column} as ascending");
        }
        else if (Sorts[found].Item2)
        {
            // Second click: Change direction to descending
            newSorts[found] = (column, false);
            Console.WriteLine($"Changed column {column} to descending");
        }
        else
        {
            // Third click: Remove column from sort list
            newSorts.RemoveAt(found);
            Console.WriteLine($"Removed column {column} from sorts");
        }
        
        Console.WriteLine($"New sorts: {string.Join(", ", newSorts.Select(s => $"{s.Item1}:{s.Item2}"))}");
        Console.WriteLine("About to invoke OnSortsChanged");

        // Check if callback is assigned before invoking
        if (OnSortsChanged.HasDelegate)
        {
            Console.WriteLine("OnSortsChanged has delegate, invoking");
            await OnSortsChanged.InvokeAsync(newSorts);
        }
        else
        {
            Console.WriteLine("WARNING: OnSortsChanged has no delegate assigned!");
        }
    }
}
