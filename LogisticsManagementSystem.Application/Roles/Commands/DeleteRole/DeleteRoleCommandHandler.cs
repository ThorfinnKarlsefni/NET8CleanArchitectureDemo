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
        var role = await _roleRepository.FindByIdAsync(command.roleId);
        if (role is null)
            return Error.Validation(description: "用户不存在");
        var ok = await _roleRepository.DeleteAsync(role);
        if (!ok.Succeeded)
            return Error.Conflict(description: "删除失败");
        return Result.Deleted;
    }
}
