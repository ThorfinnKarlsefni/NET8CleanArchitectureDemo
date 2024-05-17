using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record UpdateMenuSortCommand(
    List<MenuSortItem> Menus
)
: IAuthorizeAbleRequest<ErrorOr<Updated>>;
public record MenuSortItem(
    int Id,
    int? ParentId,
    int Sort
);