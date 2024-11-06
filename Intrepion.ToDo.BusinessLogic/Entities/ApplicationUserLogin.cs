using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
