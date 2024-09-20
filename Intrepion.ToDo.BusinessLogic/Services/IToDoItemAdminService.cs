using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IToDoItemAdminService
{
    Task<ToDoItemAdminDataTransferObject?> AddAsync(string userName, ToDoItemAdminDataTransferObject toDoItem);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoItemAdminDataTransferObject?> EditAsync(string userName, Guid id, ToDoItemAdminDataTransferObject toDoItem);
    Task<List<ToDoItemAdminDataTransferObject>?> GetAllAsync();
    Task<ToDoItemAdminDataTransferObject?> GetByIdAsync(Guid id);
}
