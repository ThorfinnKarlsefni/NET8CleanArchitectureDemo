using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateCustomerCommand(
    Guid? CompanyId,
    string? App_name,
    int Convert_status,
    string? City,
    string? Adv_name,
    string? Name,
    string? Gender,
    int Age,
    string? Telphone,
    string? Clue_convert_status,
    string? External_url,
    string? Module_name,
    string? Tag

) : IRequest<ErrorOr<Created>>;

