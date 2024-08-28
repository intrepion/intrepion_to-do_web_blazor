﻿using Intrepion.ToDo.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.Shared.Entities.Configuration;

public class ApplicationUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        builder
            .ToTable("AspNetUserLogins", x => x.IsTemporal());

        builder
            .HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUserLogins)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
