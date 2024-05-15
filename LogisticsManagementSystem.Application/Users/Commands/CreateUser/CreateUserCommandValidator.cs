using FluentValidation;
using LogisticsManagementSystem.Application;


public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IUserRepository _userRepository, IPasswordSettings _passwordSettings)
    {
        RuleFor(x => x.UserName)
            .NotNull().NotEmpty().WithMessage("用户名不能为空")
            .Matches(@"^[A-Za-z0-9]+$").WithMessage("用户名只能包含英文字符和数字")
            .MustAsync(async (userName, _) => !await _userRepository.IsExistsAsync(userName.Trim().ToUpper()))
            .WithMessage("用户名已存在");

        RuleFor(x => x.Password)
            .NotNull().NotEmpty().WithMessage("密码不能为空")
            .SetValidator(new PasswordValidator(_passwordSettings));

        RuleFor(x => x)
            .Must(x => x.Password.Trim() == x.ConfirmPassword.Trim())
            .WithMessage("两次输入的密码不一致");
    }

    private class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator(IPasswordSettings _passwordSettings)
        {
            RuleFor(password => password)
                .MinimumLength(_passwordSettings.RequiredLength)
                .WithMessage($"密码长度必须至少为 {_passwordSettings.RequiredLength} 位")
                .Must(password => password.Distinct().Count() >= _passwordSettings.RequiredUniqueChars)
                .WithMessage($"密码必须包含至少 {_passwordSettings.RequiredUniqueChars} 个唯一字符");

            if (_passwordSettings.RequireNonAlphanumeric)
            {
                RuleFor(password => password)
                    .Matches("[^a-zA-Z0-9]")
                    .WithMessage("密码必须包含至少一个非字母数字字符");
            }

            if (_passwordSettings.RequireLowercase)
            {
                RuleFor(password => password)
                    .Matches("[a-z]")
                    .WithMessage("密码必须包含至少一个小写字母");
            }

            if (_passwordSettings.RequireUppercase)
            {
                RuleFor(password => password)
                    .Matches("[A-Z]")
                    .WithMessage("密码必须包含至少一个大写字母");
            }

            if (_passwordSettings.RequireDigit)
            {
                RuleFor(password => password)
                    .Matches("[0-9]")
                    .WithMessage("密码必须包含至少一个数字");
            }
        }
    }
}
