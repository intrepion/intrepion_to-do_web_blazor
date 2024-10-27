using Intrepion.ToDo.BusinessLogic.Entities.Dtos.Admin;

namespace Intrepion.ToDo.BusinessLogic.Repositories.Admin;

public interface IToDoListAdminRepository
{
    Task<ToDoListAdminDto?> AddAsync(ToDoListAdminDto toDoList);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ToDoListAdminDto?> EditAsync(ToDoListAdminDto toDoList);
    Task<List<ToDoListAdminDto>?> GetAllAsync(string userName);
    Task<ToDoListAdminDto?> GetByIdAsync(string userName, Guid id);
}
