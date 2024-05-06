using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RoleListQueryHandler : IRequestHandler<RoleListQuery, ErrorOr<RoleListResult>>
{
    private readonly IRoleRepository _roleRepository;

    public RoleListQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<RoleListResult>> Handle(RoleListQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetRoleListAsync(request.PageNumber, request.PageSize, request.SearchKeyword, cancellationToken);
    }
}
