using AppNamePlaceholder.BusinessLogic.Entities;

namespace AppNamePlaceholder.BusinessLogic.Services;

public interface IEntityNamePlaceholderAdminService
{
    Task<EntityNamePlaceholder?> AddAsync(string userName, EntityNamePlaceholder LowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<EntityNamePlaceholder?> EditAsync(string userName, Guid id, EntityNamePlaceholder LowercaseNamePlaceholder);
    Task<List<EntityNamePlaceholder>?> GetAllAsync();
    Task<EntityNamePlaceholder?> GetByIdAsync(Guid id);
}
