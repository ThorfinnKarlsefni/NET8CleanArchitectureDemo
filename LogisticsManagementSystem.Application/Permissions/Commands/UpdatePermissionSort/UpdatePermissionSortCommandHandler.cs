using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdatePermissionSortCommandHandler(IPermissionRepository _permissionRepository) : IRequestHandler<UpdatePermissionSortCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdatePermissionSortCommand command, CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.GetListPermissionsAsync(cancellationToken);
        foreach (var permission in permissions)
        {
            var item = command.Permissions.FirstOrDefault(x => x.Id == permission.Id);
            if (item != null)
            {
                permission.UpdateSort(item.ParentId, item.Sort);
            }
        }

        await _permissionRepository.UpdateRangeAsync(permissions, cancellationToken);
        return Result.Updated;
    }
}
