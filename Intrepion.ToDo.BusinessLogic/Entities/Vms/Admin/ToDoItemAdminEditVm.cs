using System.ComponentModel.DataAnnotations;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Vms.Admin;

public class ToDoItemAdminEditVm
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static ToDoItemAdminEditVm FromToDoItemAdminDto(ToDoItemAdminDto toDoItemAdminDto)
    {
        if (toDoItemAdminDto == null)
        {
            return new ToDoItemAdminEditVm();
        }

        return new ToDoItemAdminEditVm
        {
            Id = toDoItemAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static ToDoItemAdminDto ToToDoItemAdminDto(ToDoItemAdminEditVm toDoItemAdminEditVm)
    {
        if (toDoItemAdminEditVm == null)
        {
            return new ToDoItemAdminDto();
        }

        return new ToDoItemAdminDto
        {
            Id = toDoItemAdminEditVm.Id,

            // ModelToDtoPlaceholder
        };
    }
}
