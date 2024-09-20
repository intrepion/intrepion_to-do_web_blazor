using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ToDoItemAdminEditModel
{
    public Guid Id { get; set; }

    // ModelPropertyPlaceholder

    public static ToDoItemAdminEditModel FromToDoItemAdminDataTransferObject(ToDoItemAdminDataTransferObject? toDoItemAdminDataTransferObject)
    {
        if (toDoItemAdminDataTransferObject == null)
        {
            return new ToDoItemAdminEditModel();
        }

        return new ToDoItemAdminEditModel
        {
            Id = toDoItemAdminDataTransferObject.Id,

            // DtoToModelPropertyPlaceholder
        };
    }

    public static ToDoItemAdminDataTransferObject ToToDoItemAdminDataTransferObject(ToDoItemAdminEditModel? toDoItemAdminEditModel)
    {
        if (toDoItemAdminEditModel == null)
        {
            return new ToDoItemAdminDataTransferObject();
        }

        return new ToDoItemAdminDataTransferObject
        {
            Id = toDoItemAdminEditModel.Id,

            // ModelToDtoPropertyPlaceholder
        };
    }
}
