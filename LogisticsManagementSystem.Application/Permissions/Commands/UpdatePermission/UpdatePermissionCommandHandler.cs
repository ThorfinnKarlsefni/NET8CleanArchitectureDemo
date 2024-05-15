using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdatePermissionCommandHandler(IPermissionRepository _permissionRepository) : IRequestHandler<UpdatePermissionCommand, ErrorOr<Updated>>
{

    public async Task<ErrorOr<Updated>> Handle(UpdatePermissionCommand command, CancellationToken cancellationToken)
    {
        if (command.Controller != null && command.Method != null)
        {
            var permissionItem = await _permissionRepository.IsExistAsync(command.Controller.Trim(), command.Method.Trim(), cancellationToken);
            if (permissionItem)
            {
                return Error.Conflict(description: "权限已设置");
            }
        }

        var permission = await _permissionRepository.GetByIdAsync(command.PermissionId, cancellationToken);

        if (permission == null)
        {
            return Error.Validation(description: "权限不存在");
        }

        permission.Update(
            command.ParentId,
            command.Name,
            command.Controller,
            command.Action,
            command.Method);

        await _permissionRepository.UpdateAsync(permission, cancellationToken);
        return Result.Updated;
    }
}
