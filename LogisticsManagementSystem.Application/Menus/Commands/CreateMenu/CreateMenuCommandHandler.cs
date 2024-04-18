using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Created>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Created>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = new Menu(request.ParentId, request.Name, request.Path, request.Icon, request.Component, request.Visibility);
        await _menuRepository.AddAsync(menu);
        await _menuRepository.SaveChangesAsync();
        return Result.Created;
    }
}
