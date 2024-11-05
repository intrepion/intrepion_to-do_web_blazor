namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoListGrid;

// State of grid filters.
public class ToDoListGridControls(IPageHelper pageHelper) : IToDoListFilters
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; } = pageHelper;

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    // Column to sort by.
    public ToDoListFilterColumns SortColumn { get; set; } = ToDoListFilterColumns.Title;

    // True when sorting ascending, otherwise sort descending.
    public bool SortAscending { get; set; } = true;

    // Column filtered text is against.
    public ToDoListFilterColumns FilterColumn { get; set; } = ToDoListFilterColumns.Title;

    // Text to filter on.
    public string? FilterText { get; set; }
}
