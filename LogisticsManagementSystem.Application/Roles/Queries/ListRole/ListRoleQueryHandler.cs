﻿using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListRoleQueryHandler(IRoleRepository _roleRepository) : IRequestHandler<ListRoleQuery, ErrorOr<ListRoleResult>>
{
    public async Task<ErrorOr<ListRoleResult>> Handle(ListRoleQuery request, CancellationToken cancellationToken)
    {
        var (listRoles, totalCount) = await _roleRepository.GetListRoleAsync(request.PageNumber, request.PageSize, request.SearchKeyword, cancellationToken);
        var roles = listRoles.Select(r => new ListRole(
                r.Id,
                r.Name,
                r.NormalizedName,
                r.CreatedAt,
                r.RoleMenus.Select(x => x.Menu.Id).ToList(),
                r.RolePermissions.Select(x => new ListRolePermissions(
                    x.Permission.Id,
                    x.Permission.ParentId,
                    x.Permission.Name
                )).ToList()
            ));

        return new ListRoleResult(
            totalCount,
            request.PageNumber,
            request.PageSize,
            roles.ToList()
        );
    }
}
