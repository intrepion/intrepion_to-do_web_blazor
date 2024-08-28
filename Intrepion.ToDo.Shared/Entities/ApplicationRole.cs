using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.Shared.Entities;

public class ApplicationRole : IdentityRole
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
