using Intrepion.ToDo.BusinessLogic.Entities;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IToDoListAdminService
{
    Task<ToDoList?> AddAsync(string userName, ToDoList toDoList);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoList?> EditAsync(string userName, Guid id, ToDoList toDoList);
    Task<List<ToDoList>?> GetAllAsync();
    Task<ToDoList?> GetByIdAsync(Guid id);
}
