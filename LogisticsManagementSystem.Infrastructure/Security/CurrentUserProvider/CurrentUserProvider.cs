using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LogisticsManagementSystem.Application;
using Microsoft.AspNetCore.Http;

namespace LogisticsManagementSystem.Infrastructure;

public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
{
    public CurrentUser GetCurrentUser()
    {
        var id = Guid.Parse(GetSingleClaimValue("userId"));
        var name = GetSingleClaimValue(JwtRegisteredClaimNames.Name);
        var companyId = GetSingleClaimValue("companyId");
        var roles = GetClaimValues(ClaimTypes.Role);
        var permissions = GetClaimValues("permissions");
        var securityStamp = GetSingleClaimValue("securityStamp");

        return new CurrentUser(id, name, companyId, permissions, roles, securityStamp);
    }

    private List<string> GetClaimValues(string claimType) =>
        _httpContextAccessor.HttpContext!.User!.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();

    private string GetSingleClaimValue(string claimType) =>
        _httpContextAccessor.HttpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
}
