using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.Shared.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
