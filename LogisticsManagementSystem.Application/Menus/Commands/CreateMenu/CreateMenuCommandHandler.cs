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

    public async Task<ErrorOr<Created>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = new Menu(command.ParentId, command.Name, command.Path, command.Icon, command.Component, command.Visibility);
        await _menuRepository.AddAsync(menu, cancellationToken);
        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Created;
    }
}
