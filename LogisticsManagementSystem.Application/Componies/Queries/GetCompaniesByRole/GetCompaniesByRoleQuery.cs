﻿using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetCompaniesByRoleQuery(
    IReadOnlyList<string> Role,
    List<Guid> CompanyIds
) : IRequest<ErrorOr<List<Company>>>;
