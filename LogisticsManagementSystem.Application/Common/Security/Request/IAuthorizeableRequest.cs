using MediatR;

namespace LogisticsManagementSystem.Application;

public class IAuthorizeableRequest<T> : IRequest<T>
{
    Guid UserId { get; }
}
