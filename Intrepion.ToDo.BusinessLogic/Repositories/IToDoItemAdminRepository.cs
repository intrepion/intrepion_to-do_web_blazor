using Intrepion.ToDo.BusinessLogic.Entities;
using Intrepion.ToDo.BusinessLogic.Entities.Dtos;

namespace Intrepion.ToDo.BusinessLogic.Repositories;

public interface IToDoItemAdminRepository
{
    Task<ToDoItemAdminDto?> AddAsync(ToDoItemAdminDto toDoItem);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoItemAdminDto?> EditAsync(ToDoItemAdminDto toDoItem);
    Task<List<ToDoItemAdminDto>?> GetAllAsync(string userName);
    Task<ToDoItemAdminDto?> GetByIdAsync(string userName, Guid id);
}
