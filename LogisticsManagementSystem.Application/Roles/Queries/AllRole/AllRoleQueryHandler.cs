using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class AllRoleQueryHandler : IRequestHandler<AllRoleQuery, ErrorOr<List<AllRoleResult>>>
{
    private IRoleRepository _roleRepository;

    public AllRoleQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<List<AllRoleResult>>> Handle(AllRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllRoleAsync();

        var result = roles.Select(r => new AllRoleResult(
            r.Id,
            r.Name,
            r.NormalizedName
        )).ToList();

        return result;
    }
}
