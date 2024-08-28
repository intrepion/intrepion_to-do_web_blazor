using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
