using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Entities.Models;

public class ToDoListAdminEditModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
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

            Title = toDoListAdminEditModel.Title,
            // ModelToDtoPropertyPlaceholder
        };
    }
}
