using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IToDoItemAdminService
{
    Task<ToDoItem?> AddAsync(string userName, ToDoItem EntityLowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoItem?> EditAsync(string userName, Guid id, ToDoItem EntityLowercaseNamePlaceholder);
    Task<List<ToDoItem>?> GetAllAsync();
    Task<ToDoItem?> GetByIdAsync(Guid id);
}
