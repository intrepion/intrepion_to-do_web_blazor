namespace Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

public class AdminApplicationUserEditDataTransferObject
{
    public List<ApplicationRole> ApplicationRoles { get; set; } = [];
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
