using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record CreateMenuCommand(int? ParentId, string Name, string? Controller, string Path, string? Icon, string? Component, int? Sort, bool Visibility) : IRequest<ErrorOr<Created>>;
