using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.Shared.Entities;

public class ApplicationRole : IdentityRole
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
