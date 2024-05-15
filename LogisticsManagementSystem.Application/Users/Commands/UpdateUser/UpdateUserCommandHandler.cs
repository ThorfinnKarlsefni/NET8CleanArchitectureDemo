using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateUserCommandHandler(
    IUserRepository _userRepository) : IRequestHandler<UpdateUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(command.UserId, cancellationToken);
        if (user == null)
            return Error.NotFound(description: "用户不在");
        // var isAdmin = await _userRepository.IsInAdminAsync(user);
        // if (request.CompanyId != null && !isAdmin)
        //     return Error.Validation(description: "没有权限修改公司");

        user.UpdateUser(
            command.CompanyId,
            command.Name,
            command.PhoneNumber,
            command.Email);

        user.UpdateRole(user.Id, command.Role);

        // if (command.Password != null)
        // {
        //     var resetPasswordResult = await _userRepository.ResetUserPasswordAsync(user, command.Password);
        //     if (!resetPasswordResult.Succeeded)
        //     {
        //         return Error.Conflict(description: resetPasswordResult.Errors.First().Description.ToString());
        //     }
        // }

        return Result.Updated;
    }
}
