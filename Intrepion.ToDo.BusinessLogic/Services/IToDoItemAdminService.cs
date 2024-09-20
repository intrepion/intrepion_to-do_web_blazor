using ApplicationNamePlaceholder.BusinessLogic.Entities.DataTransferObjects;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IEntityNamePlaceholderAdminService
{
    Task<EntityNamePlaceholderAdminDataTransferObject?> AddAsync(string userName, EntityNamePlaceholderAdminDataTransferObject toDoItem);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<EntityNamePlaceholderAdminDataTransferObject?> EditAsync(string userName, Guid id, EntityNamePlaceholderAdminDataTransferObject toDoItem);
    Task<List<EntityNamePlaceholderAdminDataTransferObject>?> GetAllAsync();
    Task<EntityNamePlaceholderAdminDataTransferObject?> GetByIdAsync(Guid id);
}
