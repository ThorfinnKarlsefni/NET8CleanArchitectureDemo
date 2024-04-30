using MediatR;

namespace LogisticsManagementSystem.Application;

public interface IAuthorizeAbleRequest<T> : IRequest<T>
{
    Guid UserId { get; }
}
