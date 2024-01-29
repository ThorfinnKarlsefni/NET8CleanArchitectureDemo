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

    public async Task<ErrorOr<Created>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.UserName, request.PhoneNumber, request.Avatar);
        await _userRepository.CreateAsync(user, request.Password);
        return Result.Created;
    }
}
