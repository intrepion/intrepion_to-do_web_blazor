using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IToDoListAdminService
{
    Task<ToDoListAdminDataTransferObject?> AddAsync(string userName, ToDoListAdminDataTransferObject toDoList);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoListAdminDataTransferObject?> EditAsync(string userName, Guid id, ToDoListAdminDataTransferObject toDoList);
    Task<List<ToDoListAdminDataTransferObject>?> GetAllAsync();
    Task<ToDoListAdminDataTransferObject?> GetByIdAsync(Guid id);
}
