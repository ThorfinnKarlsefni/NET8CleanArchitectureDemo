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
        var user = new User()
        {
            Id = userId,
            UserName = "Cheung",
            Name = "Cheung",
            NormalizedUserName = "CHEUNG",
            PhoneNumber = "15563239095",
            Email = "402832626@qq.com",
            PasswordHash = "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==",
            SecurityStamp = "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4",
            PhoneNumberConfirmed = false,
            LockoutEnabled = true,
        };

        builder.Entity<User>().HasData(user);
    }
    private static void SeedRoles(ModelBuilder builder, Guid roleId)
    {
        var name = "Admin";
        builder.Entity<Role>().HasData(
          new Role(name)
          {
              Id = roleId,
          });
    }

    private static void SeedUserRoles(ModelBuilder builder, Guid userId, Guid roleId)
    {
        builder.Entity<UserRole>().HasData(
           new UserRole(userId, roleId)
        );
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

            new Menu
            {
                Id = 2,
                ParentId = 1,
                Name = "菜单管理",
                Controller = "Menu",
                Path = "/admin/menus",
                Component = "./Admin/Menus"

            },
            new Menu
            {
                Id = 3,
                ParentId = 1,
                Name = "权限管理",
                Controller = "Permission",
                Path = "/admin/permissions",
                Component = "./Admin/Permissions"
            },
            new Menu
            {
                Id = 4,
                ParentId = 1,
                Name = "角色管理",
                Controller = "Role",
                Path = "/admin/roles",
                Component = "./Admin/Roles"
            },
             new Menu
             {
                 Id = 5,
                 ParentId = 1,
                 Name = "员工列表",
                 Controller = "User",
                 Path = "/admin/users",
                 Component = "./Admin/Users"
             }
        );
    }

    private static void SeedPermission(ModelBuilder builder)
    {
        builder.Entity<Permission>().HasData(
            new Permission(null, "系统", null, null, null)
            {
                Id = 1,
            },
            new Permission(1, "菜单管理", "Menu", null, null)
            {
                Id = 2,
            },
            new Permission(2, "查看", "Menu", "menu:get", "GET")
            {
                Id = 3,
            },
            new Permission(2, "创建", "Menu", "menu:create", "CREATE")
            {
                Id = 4,
            },
            new Permission(2, "修改", "Menu", "menu:update", "UPDATE")
            {
                Id = 5,
            },
            new Permission(2, "删除", "Menu", "menu:delete", "DELETE")
            {
                Id = 6,
            },
            new Permission(1, "权限管理", "Permission", null, null)
            {
                Id = 7,
            },
            new Permission(7, "查看", "Permission", "permission:get", "GET")
            {
                Id = 8,
            },
            new Permission(7, "创建", "Permission", "permission:create", "CREATE")
            {
                Id = 9,
            }, new Permission(7, "修改", "Permission", "permission:update", "UPDATE")
            {
                Id = 10,
            },
            new Permission(7, "删除", "Permission", "permission:delete", "DELETE")
            {
                Id = 11,
            },
            new Permission(1, "角色管理", "Role", null, null)
            {
                Id = 12,
            },
            new Permission(12, "查看", "Role", "role:get", "GET")
            {
                Id = 13,
            },
            new Permission(12, "创建", "Role", "role:create", "CREATE")
            {
                Id = 14,
            }, new Permission(12, "修改", "Role", "role:update", "UPDATE")
            {
                Id = 15,
            },
            new Permission(12, "删除", "Role", "role:delete", "DELETE")
            {
                Id = 16,
            }
        );
    }
}
