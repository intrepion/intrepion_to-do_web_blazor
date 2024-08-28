using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationUserToken : IdentityUserToken<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
