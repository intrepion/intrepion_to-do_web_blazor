using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationRole : IdentityRole
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
