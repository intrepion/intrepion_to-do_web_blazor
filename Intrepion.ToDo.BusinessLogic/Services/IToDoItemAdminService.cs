using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IToDoItemAdminService
{
    Task<ToDoItem?> AddAsync(string userName, ToDoItem toDoItem);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoItem?> EditAsync(string userName, Guid id, ToDoItem toDoItem);
    Task<List<ToDoItem>?> GetAllAsync();
    Task<ToDoItem?> GetByIdAsync(Guid id);
}
