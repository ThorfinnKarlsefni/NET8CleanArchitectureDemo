using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<Updated>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id);
        if (user == null)
            return Error.NotFound(description: "用户不在");
        // var isAdmin = await _userRepository.IsInAdminAsync(user);
        // if (request.CompanyId != null && !isAdmin)
        //     return Error.Validation(description: "没有权限修改公司");

        user.UpdateUser(
            request.CompanyId,
            request.Name,
            request.PhoneNumber,
            request.Email);

        user.UpdateRoles(user.Id, request.Roles);

        if (request.Password != null)
        {
            var resetPasswordResult = await _userRepository.ResetUserPasswordAsync(user, request.Password);
            if (!resetPasswordResult.Succeeded)
            {
                return Error.Conflict(description: resetPasswordResult.Errors.First().Description.ToString());
            }
        }
        // var updateUserResult = await _userRepository.UpdateAsync(user);

        await _userRepository.SaveChangeAsync();
        return Result.Updated;
    }
}
