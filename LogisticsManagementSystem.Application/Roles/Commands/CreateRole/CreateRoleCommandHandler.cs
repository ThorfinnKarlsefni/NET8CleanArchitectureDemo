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

        await _roleRepository.CreateAsync(role, cancellationToken);
        // if (!result.Succeeded)
        //     return Error.Conflict(description: result.Errors.First().Description.ToString());

        if (request.MenuIds != null && request.MenuIds.Any())
        {
            var setMenuRoleResult = role.SetMenuRoleRelation(role.Id, request.MenuIds);

            if (setMenuRoleResult.IsError)
            {
                return setMenuRoleResult.Errors;
            }
        }
        return Result.Created;
    }
}
