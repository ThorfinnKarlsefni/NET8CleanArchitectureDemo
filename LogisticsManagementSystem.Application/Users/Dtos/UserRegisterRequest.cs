using FluentValidation;

namespace LogisticsManagementSystem.Application;

public record UserRegisterRequest(string UserName, string? PhoneNumber, string? Name, string? Avatar, string Password, string ConfirmPassword);

public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.UserName)
        .NotNull().NotEmpty().WithMessage("用户不能为空")
        .MustAsync((userName, _) => userRepository.UserExistsAsync(userName)).WithMessage("用户已存在");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("密码不能为空");
        RuleFor(x => x)
                .Must(x => x.Password == x.ConfirmPassword)
                .WithMessage("两次密码不一致");
    }
}

