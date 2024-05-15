using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateUserCommandHandler(
    IUserRepository _userRepository,
    IRoleRepository _roleRepository
) : IRequestHandler<CreateUserCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(
            command.UserName,
            command.Name,
            command.CompanyId,
            command.PhoneNumber);

        if (command.RoleId.HasValue && command.RoleId != Guid.Empty)
        {
            Console.WriteLine(user.Id);
            var roles = await _roleRepository.GetAllRoleAsync(cancellationToken);

            var setRoleResult = user.SetRole(roles, user.Id, command.RoleId.Value);
            if (setRoleResult.IsError)
            {
                return setRoleResult.Errors;
            }
        }

        user.SetAvatar(command.Avatar);

        user.PasswordHash = _userRepository.EncryptPassword(command.Password.Trim());

        user.SecurityStamp = _userRepository.GenerateSecurityStamp();

        await _userRepository.CreateAsync(user, cancellationToken);



        return Result.Created;
    }
}
