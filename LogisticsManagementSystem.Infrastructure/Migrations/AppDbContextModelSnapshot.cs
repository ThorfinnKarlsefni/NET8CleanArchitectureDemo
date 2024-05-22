﻿// <auto-generated />
using System;
using LogisticsManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogisticsManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

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

                    b.Property<string>("Controller")
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

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

                    b.Property<int>("Sort")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<bool>("Visibility")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Component = "",
                            Controller = "",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2060),
                            Icon = "",
                            Name = "系统",
                            Path = "/admin",
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2060),
                            Visibility = true
                        },
                        new
                        {
                            Id = 2,
                            Component = "./Admin/Menus",
                            Controller = "Menu",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2060),
                            Icon = "",
                            Name = "菜单管理",
                            ParentId = 1,
                            Path = "/admin/menus",
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2060),
                            Visibility = true
                        },
                        new
                        {
                            Id = 3,
                            Component = "./Admin/Permissions",
                            Controller = "Permission",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2070),
                            Icon = "",
                            Name = "权限管理",
                            ParentId = 1,
                            Path = "/admin/permissions",
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2070),
                            Visibility = true
                        },
                        new
                        {
                            Id = 4,
                            Component = "./Admin/Roles",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2070),
                            Icon = "",
                            Name = "角色管理",
                            ParentId = 1,
                            Path = "/admin/roles",
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2070),
                            Visibility = true
                        },
                        new
                        {
                            Id = 5,
                            Component = "./Admin/Users",
                            Controller = "User",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2070),
                            Icon = "",
                            Name = "员工列表",
                            ParentId = 1,
                            Path = "/admin/users",
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2070),
                            Visibility = true
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Controller")
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Method")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("Sort")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2090),
                            Name = "系统",
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2090)
                        },
                        new
                        {
                            Id = 2,
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2090),
                            Name = "角色管理",
                            ParentId = 1,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2090)
                        },
                        new
                        {
                            Id = 3,
                            Action = "role:get",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2090),
                            Method = "GET",
                            Name = "查看",
                            ParentId = 2,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2090)
                        },
                        new
                        {
                            Id = 4,
                            Action = "role:create",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Method = "CREATE",
                            Name = "创建",
                            ParentId = 2,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 5,
                            Action = "role:update",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Method = "UPDATE",
                            Name = "修改",
                            ParentId = 2,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 6,
                            Action = "role:delete",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Method = "DELETE",
                            Name = "删除",
                            ParentId = 2,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 7,
                            Controller = "User",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Name = "员工管理",
                            ParentId = 1,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 8,
                            Action = "user:get",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Method = "GET",
                            Name = "查看",
                            ParentId = 7,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 9,
                            Action = "user:create",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Method = "CREATE",
                            Name = "创建",
                            ParentId = 7,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 10,
                            Action = "user:update",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100),
                            Method = "UPDATE",
                            Name = "修改",
                            ParentId = 7,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2100)
                        },
                        new
                        {
                            Id = 11,
                            Action = "user:delete",
                            Controller = "Role",
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2110),
                            Method = "DELETE",
                            Name = "删除",
                            ParentId = 7,
                            Sort = 0,
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2110)
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("762119d5-9d5e-4274-89e5-5f57e2d30505"),
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2000),
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(2000)
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.RoleMenus", b =>
                {
                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("MenuId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenus", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.RolePermissions", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions", (string)null);
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasColumnType("varchar(256)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("428e6c70-44cf-44e7-bffe-8bc1685beceb"),
                            CreatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(1820),
                            Email = "402832626@qq.com",
                            LockoutEnabled = true,
                            Name = "Cheung",
                            NormalizedUserName = "CHEUNG",
                            PasswordHash = "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==",
                            PhoneNumber = "15563239095",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4",
                            UpdatedAt = new DateTime(2024, 5, 22, 9, 19, 29, 715, DateTimeKind.Local).AddTicks(1820),
                            UserName = "Cheung"
                        });
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
                            UserId = new Guid("428e6c70-44cf-44e7-bffe-8bc1685beceb"),
                            RoleId = new Guid("762119d5-9d5e-4274-89e5-5f57e2d30505")
                        });
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.RoleMenus", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsManagementSystem.Domain.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.RolePermissions", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticsManagementSystem.Domain.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.User", b =>
                {
                    b.HasOne("LogisticsManagementSystem.Domain.Company", "Company")
                        .WithOne("User")
                        .HasForeignKey("LogisticsManagementSystem.Domain.User", "CompanyId");

                    b.Navigation("Company");
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

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Company", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Menu", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("LogisticsManagementSystem.Domain.Role", b =>
                {
                    b.Navigation("RoleMenus");

                    b.Navigation("RolePermissions");

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
