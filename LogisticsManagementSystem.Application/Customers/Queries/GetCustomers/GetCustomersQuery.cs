using ErrorOr;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public record GetCustomersQuery(
    Guid UserId,
    Guid RequestCompanyId,
    List<Guid> CompanyIds
) : IAuthorizeAbleRequest<ErrorOr<List<Customer>>>;
