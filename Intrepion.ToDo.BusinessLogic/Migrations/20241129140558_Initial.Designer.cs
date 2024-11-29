﻿// <auto-generated />
using System;
using Intrepion.ToDo.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Intrepion.ToDo.BusinessLogic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241129140558_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ToDoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ordering")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ToDoListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("ToDoListId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ToDoList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserCreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserCreatedById");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationRoles")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationRoleClaims")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoleClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationUsers")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUsers")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationUserClaims")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationUserLogins")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserLogins")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationUserRoles")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedApplicationUserTokens")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserTokens")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ToDoItem", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedToDoItems")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ToDoItems")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedToDoItems")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ToDoList", "ToDoList")
                        .WithMany("ToDoItems")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");

                    b.Navigation("ToDoList");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ToDoList", b =>
                {
                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserCreatedBy")
                        .WithMany("CreatedToDoLists")
                        .HasForeignKey("ApplicationUserCreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ToDoLists")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedToDoLists")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUserCreatedBy");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("CreatedApplicationRoleClaims");

                    b.Navigation("CreatedApplicationRoles");

                    b.Navigation("CreatedApplicationUserClaims");

                    b.Navigation("CreatedApplicationUserLogins");

                    b.Navigation("CreatedApplicationUserRoles");

                    b.Navigation("CreatedApplicationUserTokens");

                    b.Navigation("CreatedApplicationUsers");

                    b.Navigation("CreatedToDoItems");

                    b.Navigation("CreatedToDoLists");

                    b.Navigation("ToDoItems");

                    b.Navigation("ToDoLists");

                    b.Navigation("UpdatedApplicationRoleClaims");

                    b.Navigation("UpdatedApplicationRoles");

                    b.Navigation("UpdatedApplicationUserClaims");

                    b.Navigation("UpdatedApplicationUserLogins");

                    b.Navigation("UpdatedApplicationUserRoles");

                    b.Navigation("UpdatedApplicationUserTokens");

                    b.Navigation("UpdatedApplicationUsers");

                    b.Navigation("UpdatedToDoItems");

                    b.Navigation("UpdatedToDoLists");
                });

            modelBuilder.Entity("Intrepion.ToDo.BusinessLogic.Entities.ToDoList", b =>
                {
                    b.Navigation("ToDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
