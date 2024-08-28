﻿using Intrepion.ToDo.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.Shared.Entities.Configuration;

public class ApplicationRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {
        builder
            .ToTable("AspNetRoleClaims", x => x.IsTemporal());

        builder
            .HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationRoleClaims)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
