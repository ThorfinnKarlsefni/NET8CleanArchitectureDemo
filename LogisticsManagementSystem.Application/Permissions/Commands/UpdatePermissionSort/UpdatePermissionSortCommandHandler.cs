using System.Reflection;
using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdatePermissionSortCommandHandler : IRequestHandler<UpdatePermissionSortCommand, ErrorOr<Updated>>
{
    private readonly IPermissionRepository _permissionRepository;

    public UpdatePermissionSortCommandHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdatePermissionSortCommand request, CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.GetAllAsync();
        foreach (var permission in permissions)
        {
            var item = request.Permissions.Where(x => x.Id == permission.Id).SingleOrDefault();
            if (item != null)
                permission.UpdateSort(item.ParentId, item.Sort);
        }

        await _permissionRepository.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
