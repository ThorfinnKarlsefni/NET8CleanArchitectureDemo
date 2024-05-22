using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateUserCommandHandler(
    IUserRepository _userRepository,
    IRoleRepository _roleRepository) : IRequestHandler<UpdateUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(command.UserId, cancellationToken);
        if (user == null)
        {
            return Error.NotFound(description: "用户不在");
        }

        if (command.RoleId.HasValue)
        {
            var role = await _roleRepository.FindByIdAsync(command.RoleId.Value, cancellationToken);
            if (role is null)
                return Error.NotFound(description: "角色不存在");
        }

        user.UpdateRole(user.Id, command.RoleId);
        user.UpdateUser(
            command.CompanyId,
            command.Name,
            command.PhoneNumber,
            command.Email);

        // if (command.Password != null)
        // {
        //     var resetPasswordResult = await _userRepository.ResetUserPasswordAsync(user, command.Password);
        //     if (!resetPasswordResult.Succeeded)
        //     {
        //         return Error.Conflict(description: resetPasswordResult.Errors.First().Description.ToString());
        //     }
        // }
        await _userRepository.UpdateAsync(user, cancellationToken);
        return Result.Updated;
    }
}
