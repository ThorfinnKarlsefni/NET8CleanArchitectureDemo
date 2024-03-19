﻿namespace LogisticsManagementSystem.Application;

public record ListUserResult(
    long TotalCount,
    // int NormalCount,
    // int ForbiddenCount,
    int PageNumber,
    int Pagesize,
    List<ListUser>? Users
);

public record ListUser(Guid Id, string? UserName, string Name, string? Avatar, DateTime CreatedAt, IEnumerable<ListUserRoleResult> Roles);

public record ListUserRoleResult(Guid Id, string? Name);

