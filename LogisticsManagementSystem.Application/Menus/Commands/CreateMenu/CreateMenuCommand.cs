using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateMenuCommand(int? ParentId, string Name, string Path, string? Icon, string Component, int? Rank, bool HideMenu) : IRequest<ErrorOr<Created>>;
