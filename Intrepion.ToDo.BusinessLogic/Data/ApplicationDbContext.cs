using AppNamePlaceholder.BusinessLogic.Entities;
using AppNamePlaceholder.BusinessLogic.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.BusinessLogic.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationRoleClaimEntityTypeConfiguration().Configure(builder.Entity<ApplicationRoleClaim>());
        new ApplicationRoleEntityTypeConfiguration().Configure(builder.Entity<ApplicationRole>());
        new ApplicationUserEntityTypeConfiguration().Configure(builder.Entity<ApplicationUser>());
        new ApplicationUserClaimEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserClaim>());
        new ApplicationUserLoginEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserLogin>());
        new ApplicationUserRoleEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserRole>());
        new ApplicationUserTokenEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserToken>());
    }
}
