namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoListGrid;

public class ToDoListGridControls(IPageHelper pageHelper) : IToDoListFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public ToDoListFilterColumns SortColumn { get; set; } = ToDoListFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public ToDoListFilterColumns FilterColumn { get; set; } = ToDoListFilterColumns.Id;

    public string? FilterText { get; set; }
}
