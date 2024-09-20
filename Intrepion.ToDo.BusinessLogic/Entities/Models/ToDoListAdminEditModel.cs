using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ToDoListAdminEditModel
{
    public Guid Id { get; set; }

    // ModelPropertyPlaceholder

    public static ToDoListAdminEditModel FromToDoListAdminDataTransferObject(ToDoListAdminDataTransferObject? toDoListAdminDataTransferObject)
    {
        if (toDoListAdminDataTransferObject == null)
        {
            return new ToDoListAdminEditModel();
        }

        return new ToDoListAdminEditModel
        {
            Id = toDoListAdminDataTransferObject.Id,

            Title = toDoListAdminDataTransferObject.Title,
            // DtoToModelPropertyPlaceholder
        };
    }

    public static ToDoListAdminDataTransferObject ToToDoListAdminDataTransferObject(ToDoListAdminEditModel? toDoListAdminEditModel)
    {
        if (toDoListAdminEditModel == null)
        {
            return new ToDoListAdminDataTransferObject();
        }

        return new ToDoListAdminDataTransferObject
        {
            Id = toDoListAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
        };
    }
}
