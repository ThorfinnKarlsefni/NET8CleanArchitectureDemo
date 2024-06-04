using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetCompaniesQuery() : IRequest<ErrorOr<List<Company>>>;
