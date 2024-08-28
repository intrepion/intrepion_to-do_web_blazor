using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationUserClaim : IdentityUserClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
