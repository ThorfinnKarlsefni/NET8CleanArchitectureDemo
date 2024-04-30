using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        SeedUsers(builder, userId);
        SeedRoles(builder, roleId);
        SeedUserRoles(builder, userId, roleId);
        SeedMenus(builder);
        SeedPermission(builder);
    }

    private static void SeedUsers(ModelBuilder builder, Guid userId)
    {
        var userName = "Cheung";
        var name = "Cheung";
        var phoneNumber = string.Empty;
        var user = new User(userName, name, null, phoneNumber)
        {
            Id = userId,
            NormalizedUserName = "CHEUNG",
            EmailConfirmed = false,
            Email = "402832626@qq.com",
            PasswordHash = "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==",
            SecurityStamp = "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4",
            ConcurrencyStamp = "6bcef967-c50a-4573-8575-4f7e75a6c426",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
        };
        user.SetAvatar("http://124.222.5.145/avatar/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif");

        builder.Entity<User>().HasData(user)
       ;
    }
    private static void SeedRoles(ModelBuilder builder, Guid roleId)
    {
        var name = "Admin";
        builder.Entity<Role>().HasData(
          new Role(name)
          {
              Id = roleId,
              NormalizedName = "ADMIN",
          });
    }

    private static void SeedUserRoles(ModelBuilder builder, Guid userId, Guid roleId)
    {
        builder.Entity<UserRole>().HasData(
           new UserRole()
           {
               UserId = userId,
               RoleId = roleId
           });
    }

    private static void SeedMenus(ModelBuilder builder)
    {
        builder.Entity<Menu>().HasData(
            new Menu
            {
                Id = 1,
                Path = "/admin",
                Name = "系统",
            },
             new Menu { Id = 2, ParentId = 1, Path = "/admin/users", Name = "员工列表", Component = "./Admin/Users" },
            new Menu { Id = 3, ParentId = 1, Path = "/admin/menus", Name = "菜单管理", Component = "./Admin/Menus" },
            new Menu { Id = 4, ParentId = 1, Path = "/admin/permissions", Name = "权限管理", Component = "./Admin/Permissions" },
            new Menu { Id = 5, ParentId = 1, Path = "/admin/roles", Name = "角色管理", Component = "./Admin/Roles" }
            // new Menu { Id = 6, ParentId = 1, Path = "/admin/stations", Name = "站点管理", Component = "./Admin/Stations" },
            // new Menu
            // {
            //     Id = 7,
            //     Path = "/transport",
            //     Name = "运输管理",
            //     // Icon = "car",
            // },
            // new Menu { Id = 8, ParentId = 7, Path = "/transport/invoices", Name = "收货开票", Component = "./Transport/Invoices" }
        );
    }

    private static void SeedPermission(ModelBuilder builder)
    {
        builder.Entity<Permission>().HasData(
            new Permission(null, "系统", null, null, null, null)
            {
                Id = 1,
            },
            new Permission(1, "菜单管理", "Menu", "", null, null)
            {
                Id = 2,
            },
            new Permission(2, "查看", "Menu", "api/auth/menu", null, "GET")
            {
                Id = 3,
            },
            new Permission(2, "创建", "Menu", "api/auth/menu", null, "CREATE")

            {
                Id = 4,
            }, new Permission(2, "修改", "Menu", "api/auth/menu/{id}", null, "UPDATE")
            {
                Id = 5,
            },
            new Permission(2, "删除", "Menu", "api/auth/menu/{id}", null, "DELETE")
            {
                Id = 6,
            },
            new Permission(1, "权限管理", "Permission", "", null, null)
            {
                Id = 7,
            },
            new Permission(7, "查看", "Permission", "api/auth/permission", null, "GET")
            {
                Id = 8,
            },
            new Permission(7, "创建", "Permission", "api/auth/permission", null, "CREATE")
            {
                Id = 9,
            }, new Permission(7, "修改", "Permission", "api/auth/permission/{id}", null, "UPDATE")
            {
                Id = 10,
            },
            new Permission(7, "删除", "Permission", "api/auth/permission/{id}", null, "DELETE")
            {
                Id = 11,
            },
            new Permission(1, "角色管理", "Role", "", null, null)
            {
                Id = 12,
            },
            new Permission(12, "查看", "Role", "api/auth/roles", null, "GET")
            {
                Id = 13,
            },
            new Permission(12, "创建", "Role", "api/auth/role", null, "CREATE")
            {
                Id = 14,
            }, new Permission(12, "修改", "Role", "api/auth/role/{id}", null, "UPDATE")
            {
                Id = 15,
            },
            new Permission(12, "删除", "Role", "api/auth/role/{id}", null, "DELETE")
            {
                Id = 16,
            }
        );
    }
}
