using ApplicationNamePlaceholder.BusinessLogic.Entities;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IEntityNamePlaceholderAdminService
{
    Task<EntityNamePlaceholder?> AddAsync(string userName, EntityNamePlaceholder EntityLowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<EntityNamePlaceholder?> EditAsync(string userName, Guid id, EntityNamePlaceholder EntityLowercaseNamePlaceholder);
    Task<List<EntityNamePlaceholder>?> GetAllAsync();
    Task<EntityNamePlaceholder?> GetByIdAsync(Guid id);
}
