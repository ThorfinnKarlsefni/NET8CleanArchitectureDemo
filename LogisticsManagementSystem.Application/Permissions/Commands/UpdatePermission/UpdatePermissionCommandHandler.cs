using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, ErrorOr<Updated>>
{
    private readonly IPermissionRepository _permissionRepository;

    public UpdatePermissionCommandHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetByIdAsync(request.Id);
        if (permission == null)
            return Error.Validation(description: "权限不存在");
        permission.Update(request.ParentId, request.Name, request.Slug, request.Path, request.Action, request.Method);
        await _permissionRepository.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}
