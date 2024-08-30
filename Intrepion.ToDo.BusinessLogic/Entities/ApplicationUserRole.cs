using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
