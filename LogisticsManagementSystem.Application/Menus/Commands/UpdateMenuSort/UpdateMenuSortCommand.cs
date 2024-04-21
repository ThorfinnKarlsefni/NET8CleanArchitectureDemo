using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateMenuSortCommand(
    List<MenuSortItem> Menus
)
: IRequest<ErrorOr<Updated>>;
public record MenuSortItem(
    int Id,
    int? ParentId,
    int Sort
);