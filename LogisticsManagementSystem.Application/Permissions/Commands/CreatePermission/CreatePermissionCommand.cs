using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreatePermissionCommand(int? ParentId, string Name, string? Slug, string? Path, string? Action, string? Method) : IRequest<ErrorOr<Created>>;
