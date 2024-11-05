namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoListGrid;

// Interface for filtering.
public interface IToDoListFilters
{
    // The ToDoListFilterColumns being filtered on.
    ToDoListFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The ToDoListFilterColumns being sorted.
    ToDoListFilterColumns SortColumn { get; set; }
}
