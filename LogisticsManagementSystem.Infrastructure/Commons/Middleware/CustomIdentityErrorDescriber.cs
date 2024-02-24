using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Infrastructure;

public class CustomIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DuplicateUserName(string username)
    {
        return new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = $"用户名{username}已被占用 请使用其他用户名"
        };
    }
}
