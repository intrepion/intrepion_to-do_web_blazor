using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
