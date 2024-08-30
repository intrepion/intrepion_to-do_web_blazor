using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.BusinessLogic.Entities;

public class ApplicationRole : IdentityRole
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
