using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationRoleAdminService
{
    Task<ApplicationRoleAdminDataTransferObject?> AddAsync(string userName, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<ApplicationRoleAdminDataTransferObject?> EditAsync(string userName, Guid id, ApplicationRoleAdminDataTransferObject applicationRoleAdminDataTransferObject);
    Task<List<ApplicationRoleAdminDataTransferObject>?> GetAllAsync();
    Task<ApplicationRoleAdminDataTransferObject?> GetByIdAsync(Guid id);
}
