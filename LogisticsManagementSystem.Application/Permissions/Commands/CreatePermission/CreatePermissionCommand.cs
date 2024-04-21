using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreatePermissionCommand(int? ParentId, string Name, string? Slug, string HttpPath, List<int?> HttpMethod, List<int?> Menu) : IRequest<ErrorOr<Updated>>;
