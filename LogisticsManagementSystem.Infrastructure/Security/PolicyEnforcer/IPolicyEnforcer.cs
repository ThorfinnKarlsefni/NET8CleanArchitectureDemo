using ErrorOr;
using LogisticsManagementSystem.Application;

namespace LogisticsManagementSystem.Infrastructure;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize(
        CurrentUser currentUser,
        string policy
    );
}
