namespace LogisticsManagementSystem.Infrastructure;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}
