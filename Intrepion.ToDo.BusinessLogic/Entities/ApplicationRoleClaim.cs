using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
