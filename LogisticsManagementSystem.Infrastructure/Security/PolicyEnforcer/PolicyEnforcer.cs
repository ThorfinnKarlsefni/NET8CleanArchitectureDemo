using CleanArchitecture.Application.Common.Security.Roles;
using ErrorOr;
using LogisticsManagementSystem.Application;

namespace LogisticsManagementSystem.Infrastructure;

public class PolicyEnforcer : IPolicyEnforcer
{
    public ErrorOr<Success> Authorize(
        CurrentUser currentUser,
        string policy)
    {
        return policy switch
        {
            Policy.SelfOrAdmin => SelfOrAdminPolicy(currentUser),
            _ => Error.Unexpected(description: "权限策略名称未知"),
        };
    }

    private static ErrorOr<Success> SelfOrAdminPolicy(CurrentUser currentUser) =>
       currentUser.Roles.Contains(Role.Admin)
           ? Result.Success
           : Error.Forbidden(description: "用户请求失败,需要权限策略");
}
