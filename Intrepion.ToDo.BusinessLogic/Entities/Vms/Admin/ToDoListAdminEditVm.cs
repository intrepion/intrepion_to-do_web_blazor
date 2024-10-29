using System.ComponentModel.DataAnnotations;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Vms.Admin;

public class ToDoListAdminEditVm
{
    public Guid Id { get; set; }

    [Required]
    // JustModelPropertyPlaceholder

    public static ToDoListAdminEditVm FromToDoListAdminDto(ToDoListAdminDto toDoListAdminDto)
    {
        if (toDoListAdminDto == null)
        {
            return new ToDoListAdminEditVm();
        }

        return new ToDoListAdminEditVm
        {
            Id = toDoListAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static ToDoListAdminDto ToToDoListAdminDto(ToDoListAdminEditVm toDoListAdminEditVm)
    {
        if (toDoListAdminEditVm == null)
        {
            return new ToDoListAdminDto();
        }

        return new ToDoListAdminDto
        {
            Id = toDoListAdminEditVm.Id,

            // ModelToDtoPlaceholder
        };
    }
}
