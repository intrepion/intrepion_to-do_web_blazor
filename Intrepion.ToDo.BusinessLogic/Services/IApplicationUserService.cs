using Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

namespace Intrepion.ToDo.BusinessLogic.Services;

public interface IApplicationUserService
{
    Task<AdminApplicationUserEditDataTransferObject> AddAsync(string userName, AdminApplicationUserEditDataTransferObject adminApplicationUserEditDataTransferObject);
    Task<bool> DeleteAsync(string userName, string id);
    Task<AdminApplicationUserEditDataTransferObject> EditAsync(string userName, string id, AdminApplicationUserEditDataTransferObject adminApplicationUserEditDataTransferObject);
    Task<List<AdminApplicationUserListItemDataTransferObject>> GetAllAsync();
    Task<AdminApplicationUserEditDataTransferObject> GetByIdAsync(string id);
}
