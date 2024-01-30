using ErrorOr;
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
        var result = await _repository.CreateAsync(role);
        if (!result.Succeeded)
            return Error.Conflict(description: result.Errors.First().Description.ToString());
        return Result.Created;
    }
}
