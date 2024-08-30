using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUserClaim : IdentityUserClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
