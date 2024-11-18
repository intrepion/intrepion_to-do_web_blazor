namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoItemGrid;

public interface IToDoItemFilters
{
    ToDoItemFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    ToDoItemFilterColumns SortColumn { get; set; }
}
