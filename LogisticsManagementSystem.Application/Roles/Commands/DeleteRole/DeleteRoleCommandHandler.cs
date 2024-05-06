using System.Globalization;
using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, ErrorOr<Deleted>>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(command.RoleId, cancellationToken);
        if (role is null)
            return Error.NotFound(description: "用户不存在");

        await _roleRepository.DeleteAsync(role, cancellationToken);
        return Result.Deleted;
    }
}
