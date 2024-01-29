﻿using FluentValidation;

namespace LogisticsManagementSystem.Application;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IUserRepository userRepository)
    {
        RuleFor(x => x.UserName)
            .NotNull().NotEmpty().WithMessage("用户不能为空")
            .MustAsync((UserName, _) => userRepository.UserExistsAsync(UserName)).WithMessage("用户已存在");
        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("密码不能为空");
        RuleFor(x => x)
            .Must(x => x.Password == x.ConfirmPassword)
            .WithMessage("两次密码不一致");
    }
}