﻿// <auto-generated />
using System;
using LogisticsManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogisticsManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240219080234_AddCompany")]
    partial class AddCompany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<Guid?>("UpdateUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("UpdateUserId");

                    b.ToTable("Companies", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Component")
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<bool>("HideMenu")
                        .HasColumnType("boolean");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Component = "",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990),
                            HideMenu = false,
                            Icon = "",
                            Name = "系统",
                            Path = "/admin",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990)
                        },
                        new
                        {
                            Id = 2,
                            Component = "./Admin/Users",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990),
                            HideMenu = false,
                            Icon = "",
                            Name = "员工列表",
                            ParentId = 1,
                            Path = "/admin/users",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990)
                        },
                        new
                        {
                            Id = 3,
                            Component = "./Admin/Menu",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000),
                            HideMenu = false,
                            Icon = "",
                            Name = "菜单管理",
                            ParentId = 1,
                            Path = "/admin/menu",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000)
                        },
                        new
                        {
                            Id = 4,
                            Component = "./Admin/Permission",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000),
                            HideMenu = false,
                            Icon = "",
                            Name = "权限管理",
                            ParentId = 1,
                            Path = "/admin/permission",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000)
                        },
                        new
                        {
                            Id = 5,
                            Component = "./Admin/Role",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000),
                            HideMenu = false,
                            Icon = "",
                            Name = "角色管理",
                            ParentId = 1,
                            Path = "/admin/role",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000)
                        },
                        new
                        {
                            Id = 6,
                            Component = "./Admin/Station",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000),
                            HideMenu = false,
                            Icon = "",
                            Name = "站点管理",
                            ParentId = 1,
                            Path = "/admin/station",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000)
                        },
                        new
                        {
                            Id = 7,
                            Component = "",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000),
                            HideMenu = false,
                            Icon = "",
                            Name = "运输管理",
                            Path = "/transport",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000)
                        },
                        new
                        {
                            Id = 8,
                            Component = "./Transport/Invoices",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8010),
                            HideMenu = false,
                            Icon = "",
                            Name = "收货开票",
                            ParentId = 7,
                            Path = "/transport/invoices",
                            Rank = 0,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8010)
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.MenuRole", b =>
                {
                    b.Property<int?>("MenuId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uuid");

                    b.ToTable("MenuRoles", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("HttpMethod")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("HttpPath")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f8787e73-d392-4259-a5c8-0f19519d2750"),
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7960),
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7960)
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Avatar")
                        .HasColumnType("varchar(256)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("TokenVersion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8fe4b8b7-5723-488d-bdfa-0f0eee91dddb"),
                            AccessFailedCount = 0,
                            Avatar = "http://avatar.xhwt56.com/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif",
                            ConcurrencyStamp = "6bcef967-c50a-4573-8575-4f7e75a6c426",
                            CreatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7870),
                            Email = "402832626@qq.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            Name = "Cheung",
                            NormalizedUserName = "CHEUNG",
                            PasswordHash = "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4",
                            TokenVersion = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7900),
                            UserName = "Cheung"
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8fe4b8b7-5723-488d-bdfa-0f0eee91dddb"),
                            RoleId = new Guid("f8787e73-d392-4259-a5c8-0f19519d2750")
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Company", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId");

                    b.HasOne("LogisticsManagementSystem.Domain.User", "UpdateUser")
                        .WithMany()
                        .HasForeignKey("UpdateUserId");

                    b.Navigation("CreateUser");

                    b.Navigation("UpdateUser");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.RoleClaim", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.User", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.Company", "Company")
                        .WithOne("User")
                        .HasForeignKey("LogisticsManagementSystem.Domain.User", "CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserClaim", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserLogin", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserRole", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsManagementSystem.Domain.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.UserToken", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Company", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}