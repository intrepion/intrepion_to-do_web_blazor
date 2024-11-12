namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoItemGrid;

// Interface for filtering.
public interface IToDoItemFilters
{
    // The ToDoItemFilterColumns being filtered on.
    ToDoItemFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The ToDoItemFilterColumns being sorted.
    ToDoItemFilterColumns SortColumn { get; set; }
}
