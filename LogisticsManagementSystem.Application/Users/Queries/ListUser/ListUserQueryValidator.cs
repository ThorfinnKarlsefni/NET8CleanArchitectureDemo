using FluentValidation;

namespace LogisticsManagementSystem.Application;

public class ListUserQueryValidator : AbstractValidator<ListUserQuery>
{
    public ListUserQueryValidator()
    {
        RuleFor(x => x.PageSize)
            .LessThan(50).WithMessage("查询数量过大");
    }
}
