using ErrorOr;
using LogisticsManagementSystem.Application;

namespace LogisticsManagementSystem.Infrastructure;

public class AuthorizationService(
    IPolicyEnforcer _policyEnforcer,
    IUserRepository _userRepository,
    ICurrentUserProvider _currentUserProvider)
        : IAuthorizationService
{
    public ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeAbleRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies)
    {
        var currentUser = _currentUserProvider.GetCurrentUser();

        if (!_userRepository.CheckSecurityStamp(currentUser.Id, currentUser.SecurityStamp))
        {
            return Error.Unauthorized(description: "用户已在其他设备登录");
        }

        bool hasRequiredRole = requiredRoles.Intersect(currentUser.Roles).Any();
        bool hasRequiredPermission = requiredPermissions.Intersect(currentUser.Permissions).Any();
        bool hasRequiredPolicy = requiredPolicies.Any(policy => !_policyEnforcer.Authorize(currentUser, policy).IsError);

        if (hasRequiredRole || hasRequiredPermission || hasRequiredPolicy)
        {
            return Result.Success;
        }

        if (requiredPermissions.Except(currentUser.Permissions).Any())
        {
            return Error.Forbidden(description: "用户缺少执行此操作所需的权限");
        }

        if (requiredRoles.Except(currentUser.Roles).Any())
        {
            return Error.Forbidden(description: "用户缺少执行此操作所需的角色");
        }

        foreach (var policy in requiredPolicies)
        {
            var authorizationAgainstPolicyResult = _policyEnforcer.Authorize(currentUser, policy);
            if (authorizationAgainstPolicyResult.IsError)
            {
                return authorizationAgainstPolicyResult.Errors;
            }
        }

        return Result.Success;
    }
}