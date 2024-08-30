using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserClaim : IdentityUserClaim<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
