using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IToDoListAdminService
{
    Task<ToDoList?> AddAsync(string userName, ToDoList EntityLowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoList?> EditAsync(string userName, Guid id, ToDoList EntityLowercaseNamePlaceholder);
    Task<List<ToDoList>?> GetAllAsync();
    Task<ToDoList?> GetByIdAsync(Guid id);
}
