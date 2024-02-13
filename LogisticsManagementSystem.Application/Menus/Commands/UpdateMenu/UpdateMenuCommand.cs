﻿using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateMenuCommand(int Id, int? ParentId, string Name, string Path, string? Icon, string Component, int? Rank, bool HideMenu) : IRequest<ErrorOr<Updated>>;