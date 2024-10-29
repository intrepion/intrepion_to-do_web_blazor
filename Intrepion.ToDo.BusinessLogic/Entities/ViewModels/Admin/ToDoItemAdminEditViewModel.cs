using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class ToDoItemAdminEditViewModel
{
    public Guid Id { get; set; }

    public bool IsCompleted { get; set; }
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

            // ModelToDtoPlaceholder
        };
    }
}
