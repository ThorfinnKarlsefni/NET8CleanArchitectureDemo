namespace LogisticsManagementSystem.Application.Common.Security.Permissions;

public static partial class Permission
{
    public static class User
    {
        public const string Create = "user:create";
        public const string Delete = "user:delete";
        public const string Update = "user:update";
        public const string Get = "user:get";
    }
}
