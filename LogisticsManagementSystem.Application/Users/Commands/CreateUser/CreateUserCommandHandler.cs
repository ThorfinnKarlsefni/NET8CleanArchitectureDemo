using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Created>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Created>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(
            command.UserName,
            command.Name,
            command.companyId,
            command.PhoneNumber);
        user.SetAvatar(command.Avatar);

        var result = await _userRepository.CreateAsync(user, command.Password);
        if (!result.Succeeded)
            return Error.Conflict(description: result.Errors.First().Description.ToString());

        return Result.Created;
    }
}
