using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdatePermissionSortCommandHandler(IPermissionRepository _permissionRepository) : IRequestHandler<UpdatePermissionSortCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdatePermissionSortCommand request, CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.GetPermissionsAsync(cancellationToken);
        foreach (var permission in permissions)
        {
            var item = request.Permissions.Where(x => x.PermissionId == permission.Id).SingleOrDefault();
            if (item != null)
                permission.UpdateSort(item.ParentId, item.Sort);
        }

        await _permissionRepository.UpdateRangeAsync(permissions, cancellationToken);
        return Result.Updated;
    }
}
