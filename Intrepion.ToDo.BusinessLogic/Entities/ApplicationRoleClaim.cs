using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
