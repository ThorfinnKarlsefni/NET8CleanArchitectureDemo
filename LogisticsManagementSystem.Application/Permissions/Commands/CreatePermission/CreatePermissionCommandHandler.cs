using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ErrorOr<Created>>
{
    private readonly IPermissionRepository _permissionRepository;

    public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<ErrorOr<Created>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {

        var permission = new Permission(request.ParentId, request.Name, request.Slug, request.Path, request.Action, request.Method);
        await _permissionRepository.AddAsync(permission, cancellationToken);
        await _permissionRepository.SaveChangesAsync(cancellationToken);
        return Result.Created;
    }
}
