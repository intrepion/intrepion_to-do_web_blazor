﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Intrepion.ToDo.BusinessLogic.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = [];
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public ICollection<ApplicationRole> UpdatedApplicationRoles { get; set; } = [];
    public ICollection<ApplicationRoleClaim> UpdatedApplicationRoleClaims { get; set; } = [];
    public ICollection<ApplicationUser> UpdatedApplicationUsers { get; set; } = [];
    public ICollection<ApplicationUserClaim> UpdatedApplicationUserClaims { get; set; } = [];
    public ICollection<ApplicationUserLogin> UpdatedApplicationUserLogins { get; set; } = [];
    public ICollection<ApplicationUserRole> UpdatedApplicationUserRoles { get; set; } = [];
    public ICollection<ApplicationUserToken> UpdatedApplicationUserTokens { get; set; } = [];

    public ICollection<ToDoItem> UpdatedToDoItems { get; set; } = [];
    public ICollection<ToDoItem> ToDoItems { get; set; } = [];
    public ICollection<ToDoList> UpdatedToDoLists { get; set; } = [];
    public ICollection<ToDoList> ToDoLists { get; set; } = [];
    // ActualPropertyPlaceholder
}
