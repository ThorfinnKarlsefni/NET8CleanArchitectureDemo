using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record UpdateMenuCommand(int MenuId, int? ParentId, string Name, string? Controller, string Path, string? Icon, string? Component, int? Sort, bool Visibility) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
