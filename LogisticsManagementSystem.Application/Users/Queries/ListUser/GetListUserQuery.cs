using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetListUserQuery() : IRequest<ErrorOr<List<ListUserResponse>?>>;