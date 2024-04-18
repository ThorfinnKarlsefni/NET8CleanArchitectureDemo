using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateMenuSortCommand(
    List<ListMenu> Menus
) : IRequest<ErrorOr<Updated>>;

public record ListMenu(
    int Id,
    int? ParentId,
    int Sort
);
