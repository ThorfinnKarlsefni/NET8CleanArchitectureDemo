using FluentValidation;

namespace LogisticsManagementSystem.Application;

public class UserListQueryValidator : AbstractValidator<UserListQuery>
{
    public UserListQueryValidator()
    {
        RuleFor(x => x.PageSize)
            .LessThan(50).WithMessage("查询数量过大");
    }
}
