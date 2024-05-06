﻿using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ErrorOr<Created>>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Created>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (request.Name is null)
            return Error.Validation(description: "角色名称不能为空");

        var role = new Role(request.Name);

        await _repository.CreateAsync(role, cancellationToken);
        // if (!result.Succeeded)
        //     return Error.Conflict(description: result.Errors.First().Description.ToString());

        if (request.menuIds != null && request.menuIds.Any())
        {
            var setMenuRoleResult = role.SetMenuRoleRelation(role.Id, request.menuIds);

            if (setMenuRoleResult.IsError)
            {
                return setMenuRoleResult.Errors;
            }
        }
        return Result.Created;
    }
}
