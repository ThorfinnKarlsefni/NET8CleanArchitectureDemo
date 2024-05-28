using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public record ListCompanyResult(
    List<Company>? Companies,
    long TotalCount
);
