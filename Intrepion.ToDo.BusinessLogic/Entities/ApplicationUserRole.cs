﻿using Microsoft.AspNetCore.Identity;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public ApplicationRole? ApplicationRole { get; set; }

    // ActualPropertyPlaceholder
}
