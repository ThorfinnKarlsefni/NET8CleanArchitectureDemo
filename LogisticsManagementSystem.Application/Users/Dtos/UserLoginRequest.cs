using FluentValidation;

namespace LogisticsManagementSystem.Application;

public record UserLoginRequest(string UserName, string Password);


public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("用户名不能为空");
        RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("密码不能为空");
    }
}