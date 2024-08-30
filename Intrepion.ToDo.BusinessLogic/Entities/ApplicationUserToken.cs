using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
