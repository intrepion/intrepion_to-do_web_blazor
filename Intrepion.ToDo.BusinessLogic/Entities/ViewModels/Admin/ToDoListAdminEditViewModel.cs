using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Entities.ViewModels.Admin;

public class ToDoListAdminEditViewModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder

    public static ToDoListAdminEditViewModel FromToDoListAdminDto(ToDoListAdminDto toDoListAdminDto)
    {
        if (toDoListAdminDto == null)
        {
            return new ToDoListAdminEditViewModel();
        }

        return new ToDoListAdminEditViewModel
        {
            Id = toDoListAdminDto.Id,

            Title = toDoListAdminDto.Title,
            // DtoToModelPlaceholder
        };
    }

    public static ToDoListAdminDto ToToDoListAdminDto(ToDoListAdminEditViewModel toDoListAdminEditViewModel)
    {
        if (toDoListAdminEditViewModel == null)
        {
            return new ToDoListAdminDto();
        }

        return new ToDoListAdminDto
        {
            Id = toDoListAdminEditViewModel.Id,

            Title = toDoListAdminEditViewModel.Title,
            // ModelToDtoPlaceholder
        };
    }
}
