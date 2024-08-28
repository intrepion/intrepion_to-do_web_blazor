using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.Shared.Entities;

public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
