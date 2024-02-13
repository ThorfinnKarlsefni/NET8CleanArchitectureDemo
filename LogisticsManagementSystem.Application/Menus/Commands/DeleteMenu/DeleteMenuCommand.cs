using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record DeleteMenuCommand(int Id) : IRequest<ErrorOr<Deleted>>;
