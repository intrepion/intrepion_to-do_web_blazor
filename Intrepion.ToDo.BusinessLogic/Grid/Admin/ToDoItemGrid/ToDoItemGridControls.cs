namespace Intrepion.ToDo.BusinessLogic.Grid.Admin.ToDoItemGrid;

public class ToDoItemGridControls(IPageHelper pageHelper) : IToDoItemFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public ToDoItemFilterColumns SortColumn { get; set; } = ToDoItemFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public ToDoItemFilterColumns FilterColumn { get; set; } = ToDoItemFilterColumns.Id;

    public string? FilterText { get; set; }
}
