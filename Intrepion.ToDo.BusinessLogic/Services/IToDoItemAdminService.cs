using AppNamePlaceholder.BusinessLogic.Entities;

namespace AppNamePlaceholder.BusinessLogic.Services;

public interface IToDoItemAdminService
{
    Task<ToDoItem?> AddAsync(string userName, ToDoItem LowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoItem?> EditAsync(string userName, Guid id, ToDoItem LowercaseNamePlaceholder);
    Task<List<ToDoItem>?> GetAllAsync();
    Task<ToDoItem?> GetByIdAsync(Guid id);
}
