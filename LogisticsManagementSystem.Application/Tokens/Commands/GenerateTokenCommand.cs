using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GenerateTokenCommand(Guid UserId, string Name, Guid? CompanyId, List<string> Roles, List<string?> Permissions, string SecurityStamp) : IRequest<ErrorOr<GenerateTokenResult>>;
