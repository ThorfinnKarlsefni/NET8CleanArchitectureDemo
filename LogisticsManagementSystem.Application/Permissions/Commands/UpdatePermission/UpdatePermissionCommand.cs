using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdatePermissionCommand(int PermissionId, int? ParentId, string Name, string? Controller, string? Action, string? Method) : IRequest<ErrorOr<Updated>>;

