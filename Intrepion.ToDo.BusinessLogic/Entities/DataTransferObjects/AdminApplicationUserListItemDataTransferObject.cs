namespace Intrepion.ToDo.BusinessLogic.Entities.DataTransferObjects;

public class AdminApplicationUserListItemDataTransferObject
{
    public List<ApplicationRole>? ApplicationRoles { get; set; }
    public string? Email { get; set; }
    public Guid Id { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
}
