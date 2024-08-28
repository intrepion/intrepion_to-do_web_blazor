using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
