using ErrorOr;

namespace LogisticsManagementSystem.Application;

public record UpdateCompanyCommand(
    Guid CompanyId,
    string Name,
    string? PhoneNumber,
    string? Address,
    bool IsDisable
) : IAuthorizeAbleRequest<ErrorOr<Updated>>;

