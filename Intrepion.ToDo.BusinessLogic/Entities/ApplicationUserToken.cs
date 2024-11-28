using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
