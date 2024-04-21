using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ErrorOr<Updated>>
{
    private readonly IPermissionRepository _permissionRepository;

    public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = new Permission(request.ParentId, request.Name, request.HttpPath, request.HttpMethod.ToString());
        await _permissionRepository.AddAsync(permission);
        await _permissionRepository.SaveChangesAsync();
        return Result.Updated;
    }
}
