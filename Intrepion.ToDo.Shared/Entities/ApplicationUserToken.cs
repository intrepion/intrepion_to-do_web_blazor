using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.Shared.Entities;

public class ApplicationUserToken : IdentityUserToken<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
