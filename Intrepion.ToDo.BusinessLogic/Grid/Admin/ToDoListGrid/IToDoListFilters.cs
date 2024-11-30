namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoListGrid;

public interface IToDoListFilters
{
    ToDoListFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    ToDoListFilterColumns SortColumn { get; set; }
}
