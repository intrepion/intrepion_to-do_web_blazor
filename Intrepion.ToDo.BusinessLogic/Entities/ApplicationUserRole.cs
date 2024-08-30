using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
