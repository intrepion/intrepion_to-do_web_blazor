using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class ToDoItemAdminEditViewModel
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
    public int Ordering { get; set; }
    public ToDoList? ToDoList { get; set; }
    // JustModelPropertyPlaceholder

    public static ToDoItemAdminEditViewModel FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditViewModel();
        }

        return new ToDoItemAdminEditViewModel
        {
            Id = toDoItemAdminDto.Id,

            IsCompleted = toDoItemAdminDto?.IsCompleted ?? false,
            Ordering = toDoItemAdminDto?.Ordering ?? -1,
            // DtoToModelPlaceholder
        };
    }

    public static ToDoItemAdminDto ToToDoItemAdminDto(ToDoItemAdminEditViewModel toDoItemAdminEditViewModel)
    {
        if (toDoItemAdminEditViewModel == null)
        {
            return new ToDoItemAdminDto();
        }

        return new ToDoItemAdminDto
        {
            Id = toDoItemAdminEditViewModel.Id,

            IsCompleted = toDoItemAdminEditViewModel.IsCompleted,
            Ordering = toDoItemAdminEditViewModel.Ordering,
            // ModelToDtoPlaceholder
        };
    }
}
