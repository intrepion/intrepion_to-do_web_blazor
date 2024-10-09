﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intrepion.ToDo.BusinessLogic.Entities.Configuration;

public class ToDoItemEntityTypeConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable("ToDoItems", x => x.IsTemporal());

        builder.HasOne(x => x.ToDoList)
            .WithMany(x => x.ListItems)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
        // builder.Property(x => x.PropertyNamePlaceholder);

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedToDoItems)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
