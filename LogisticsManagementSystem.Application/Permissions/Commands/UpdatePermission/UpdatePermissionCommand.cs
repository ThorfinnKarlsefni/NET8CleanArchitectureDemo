using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdatePermissionCommand(int Id, int? ParentId, string Name, string? Slug, string? Path, string? Action, string? Method) : IRequest<ErrorOr<Updated>>;

