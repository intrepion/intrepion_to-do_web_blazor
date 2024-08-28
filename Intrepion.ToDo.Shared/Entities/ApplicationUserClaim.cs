using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.Shared.Entities;

public class ApplicationUserClaim : IdentityUserClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
