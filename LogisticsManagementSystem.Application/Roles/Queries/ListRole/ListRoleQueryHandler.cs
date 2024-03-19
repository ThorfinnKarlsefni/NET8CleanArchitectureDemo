using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListRoleQueryHandler : IRequestHandler<ListRoleQuery, ErrorOr<ListRoleResult>>
{
    private readonly IRoleRepository _roleRepository;

    public ListRoleQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<ListRoleResult>> Handle(ListRoleQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetListRoleAsync(request.PageNumber, request.Pagesize, request.SearchKeyword);
    }
}
