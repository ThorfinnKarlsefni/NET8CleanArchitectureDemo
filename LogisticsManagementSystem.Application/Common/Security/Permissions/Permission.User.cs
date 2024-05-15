namespace LogisticsManagementSystem.Application.Common.Security.Permissions;

public static partial class Permission
{
    public static class User
    {
        public const string Create = "create:user";
        public const string Delete = "delete:user";
        public const string Update = "update:user";
        public const string Get = "get:role";
    }
}
