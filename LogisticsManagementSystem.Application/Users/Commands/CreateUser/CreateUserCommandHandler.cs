using System.Linq.Expressions;
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
        var user = new User(
            request.UserName,
            request.Name,
            request.companyId,
            request.PhoneNumber);
        user.SetAvatar(request.Avatar);

        var result = await _userRepository.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return Error.Conflict(description: result.Errors.First().Description.ToString());

        return Result.Created;
    }
}
