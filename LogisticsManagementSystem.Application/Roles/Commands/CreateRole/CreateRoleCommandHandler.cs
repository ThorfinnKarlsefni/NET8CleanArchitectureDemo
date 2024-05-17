using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateRoleCommandHandler(IRoleRepository _roleRepository) : IRequestHandler<CreateRoleCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (request.Name is null)
            return Error.Validation(description: "角色名称不能为空");

        var role = new Role(request.Name);

        var setMenuRoleResult = role.SetRoleMenus(role.Id, request?.MenuIds);

        if (setMenuRoleResult.IsError)
        {
            return setMenuRoleResult.Errors;
        }

        await _roleRepository.CreateAsync(role, cancellationToken);

        return Result.Created;
    }
}
