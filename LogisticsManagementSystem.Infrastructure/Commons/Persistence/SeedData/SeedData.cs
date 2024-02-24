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
        user.SetAvatar("http://avatar.xhwt56.com/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif");

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
            new Menu { Id = 3, ParentId = 1, Path = "/admin/menu", Name = "菜单管理", Component = "./Admin/Menu" },
            new Menu { Id = 4, ParentId = 1, Path = "/admin/permission", Name = "权限管理", Component = "./Admin/Permission" },
            new Menu { Id = 5, ParentId = 1, Path = "/admin/role", Name = "角色管理", Component = "./Admin/Role" },
            new Menu { Id = 6, ParentId = 1, Path = "/admin/station", Name = "站点管理", Component = "./Admin/Station" },
            new Menu
            {
                Id = 7,
                Path = "/transport",
                Name = "运输管理",
                // Icon = "car",
            },
            new Menu { Id = 8, ParentId = 7, Path = "/transport/invoices", Name = "收货开票", Component = "./Transport/Invoices" }
        );
    }
}
