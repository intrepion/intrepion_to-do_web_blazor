using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.Shared.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
