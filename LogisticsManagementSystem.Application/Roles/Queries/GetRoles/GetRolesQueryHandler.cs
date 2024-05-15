using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetRolesQueryHandler(IRoleRepository _roleRepository) : IRequestHandler<GetRolesQuery, ErrorOr<List<GetRolesResult>>>
{
    public async Task<ErrorOr<List<GetRolesResult>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {

        var roles = await _roleRepository.GetAllRoleAsync(cancellationToken);

        var result = roles.Select(r => new GetRolesResult(
            r.Id,
            r.Name,
            r.NormalizedName
        )).ToList();

        return result;
    }
}
