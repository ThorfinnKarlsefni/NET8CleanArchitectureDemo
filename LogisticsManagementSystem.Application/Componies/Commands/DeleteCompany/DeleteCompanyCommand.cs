using ErrorOr;

namespace LogisticsManagementSystem.Application;

public record DeleteCompanyCommand(
    Guid CompanyId
) : IAuthorizeAbleRequest<ErrorOr<Deleted>>;
