using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories;

public interface IToDoListAdminRepository
{
    Task<ToDoListAdminDto?> AddAsync(ToDoListAdminDto toDoList);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoListAdminDto?> EditAsync(ToDoListAdminDto toDoList);
    Task<List<ToDoListAdminDto>?> GetAllAsync(string userName);
    Task<ToDoListAdminDto?> GetByIdAsync(string userName, Guid id);
}
