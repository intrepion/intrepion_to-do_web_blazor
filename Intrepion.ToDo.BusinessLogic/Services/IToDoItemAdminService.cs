using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IToDoItemAdminService
{
    Task<ToDoItemAdminDto?> AddAsync(ToDoItemAdminDto toDoItem);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoItemAdminDto?> EditAsync(ToDoItemAdminDto toDoItem);
    Task<List<ToDoItem>?> GetAllAsync(string userName);
    Task<ToDoItemAdminDto?> GetByIdAsync(string userName, Guid id);
}
