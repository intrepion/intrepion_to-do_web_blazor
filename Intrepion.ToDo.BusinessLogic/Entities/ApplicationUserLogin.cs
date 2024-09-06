using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
