using CleanArchitecture.Application.Common.Security.Roles;
using ErrorOr;
using LogisticsManagementSystem.Application;

namespace LogisticsManagementSystem.Infrastructure;

public class PolicyEnforcer : IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeAbleRequest<T> request,
        CurrentUser currentUser,
        string policy)
    {
        return policy switch
        {
            Policy.SelfOrAdmin => SelfOrAdminPolicy(request, currentUser),
            _ => Error.Unexpected(description: "Unknown policy name"),
        };
    }

    private static ErrorOr<Success> SelfOrAdminPolicy<T>(IAuthorizeAbleRequest<T> request, CurrentUser currentUser) =>
       request.UserId == currentUser.Id || currentUser.Roles.Contains(Role.Admin)
           ? Result.Success
           : Error.Unauthorized(description: "Requesting user failed policy requirement");
}
