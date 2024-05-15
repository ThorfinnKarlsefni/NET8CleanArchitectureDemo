using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GenerateTokenQueryHandler(IJwtTokenGenerator _jwtTokenGenerator) : IRequestHandler<GenerateTokenCommand, ErrorOr<GenerateTokenResult>>
{
    public Task<ErrorOr<GenerateTokenResult>> Handle(GenerateTokenCommand command, CancellationToken cancellationToken)
    {
        var token = _jwtTokenGenerator.GenerateToken(command.UserId, command.Name, command.CompanyId, command.Roles, command.Permissions, command.SecurityStamp);

        return Task.FromResult(ErrorOrFactory.From(new GenerateTokenResult(token)));
    }
}
