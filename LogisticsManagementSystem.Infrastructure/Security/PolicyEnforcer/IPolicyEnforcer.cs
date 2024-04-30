using ErrorOr;
using LogisticsManagementSystem.Application;

namespace LogisticsManagementSystem.Infrastructure;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeAbleRequest<T> request,
        CurrentUser currentUser,
        string policy
    );
}
