using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class AllMenuQueryHandler : IRequestHandler<AllMenuQuery, ErrorOr<List<Menu?>>>
{
    private readonly IMenuRepository _menuRepository;

    public AllMenuQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu?>>> Handle(AllMenuQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetAllMenuListAsync();
    }
}
