using ErrorOr;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public record GetCustomersQuery(
    Guid? RequestCompanyId,
    Guid UserId,
    IReadOnlyList<string> Roles,
    List<Guid> CompanyIds
) : IAuthorizeAbleRequest<ErrorOr<List<Customer>>>;
