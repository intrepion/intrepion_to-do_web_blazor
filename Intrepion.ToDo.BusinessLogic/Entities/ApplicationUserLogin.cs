using Microsoft.AspNetCore.Identity;

namespace AppNamePlaceholder.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
