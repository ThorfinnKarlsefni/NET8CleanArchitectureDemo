﻿using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Infrastructure;

public class SeedDataInitializer(AppDbContext _dbContext)
{
    public void Initialize()
    {
        if (!_dbContext.Users.Any())
        {
            SeedAdminUserRoles();
        }

        if (!_dbContext.Menus.Any())
        {
            SeedMenus();
        }

        if (!_dbContext.Permissions.Any())
        {
            SeedPermission();
        }
        _dbContext.SaveChanges();
    }

    private void SeedAdminUserRoles()
    {
        var userId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
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
        var role = new Role("Admin")
        {
            Id = roleId
        };
        var userRole = new UserRole(userId, roleId);
        _dbContext.Users.Add(user);
        _dbContext.Roles.Add(role);
        _dbContext.UserRoles.Add(userRole);
    }

    private void SeedMenus()
    {
        var menus = new List<Menu> {
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
            },
            new Menu{
                Id = 6,
                ParentId = 1,
                Name = "公司管理",
                Controller = "Company",
                Path = "/admin/companies",
                Component = "./Admin/Companies"
            }
        };
        _dbContext.Menus.AddRange(menus);
    }

    private void SeedPermission()
    {
        var permissions = new List<Permission>
        {
             new Permission(null, "系统", null, null, null)
            {
                Id = 1,
            },
            new Permission(1, "角色管理", "Role", null, null)
            {
                Id = 2,
            },
            new Permission(2, "查看", "Role", "role:get", "GET")
            {
                Id = 3,
            },
            new Permission(2, "创建", "Role", "role:create", "CREATE")
            {
                Id = 4,
            }, new Permission(2, "修改", "Role", "role:update", "UPDATE")
            {
                Id = 5,
            },
            new Permission(2, "删除", "Role", "role:delete", "DELETE")
            {
                Id = 6,
            },
            new Permission(1, "员工管理", "User", null, null)
            {
                Id = 7,
            },
            new Permission(7, "查看", "User", "user:get", "GET")
            {
                Id = 8,
            },
            new Permission(7, "创建", "User", "user:create", "CREATE")
            {
                Id = 9,
            }, new Permission(7, "修改", "User", "user:update", "UPDATE")
            {
                Id = 10,
            },
            new Permission(7, "删除", "User", "user:delete", "DELETE")
            {
                Id = 11,
            }
        };
        _dbContext.Permissions.AddRange(permissions);

    }
}
