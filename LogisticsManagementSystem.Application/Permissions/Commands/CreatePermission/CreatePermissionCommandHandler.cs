using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreatePermissionCommandHandler(IPermissionRepository _permissionRepository) : IRequestHandler<CreatePermissionCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
    {

        if (command.Controller != null && command.Method != null)
        {
            var permissionItem = await _permissionRepository.IsExistAsync(command.Controller.Trim(), command.Method.Trim(), cancellationToken);
            if (permissionItem)
            {
                return Error.Conflict(description: "权限已设置");
            }
        }

        var permission = new Permission(command.ParentId, command.Name, command.Controller, command.Action, command.Method);

        await _permissionRepository.AddAsync(permission, cancellationToken);
        return Result.Created;
    }
}
