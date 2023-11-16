using System.Security.Claims;
using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Core.Security.Permissions;

namespace noo.api.Core.Request;

[RegisterClassAsScoped]
public class RequestContext : IRequestContext
{
    public string? UserId { get; private set; }
    public string? UserRole { get; private set; }
    public bool IsBlocked { get; private set; }
    public PermissionResolver PermissionResolver { get; private set; }

    public RequestContext()
    {
        PermissionResolver = new PermissionResolver(0);
    }

    public void ApplyClaims(IEnumerable<Claim> claims)
    {
        var claimsList = claims.ToList();

        try
        {
            UserId = claimsList.FirstOrDefault(c => c.Type == "user_id")?.Value;
            UserRole = claimsList.FirstOrDefault(c => c.Type == "user_role")?.Value;
            IsBlocked = bool.Parse(claimsList.FirstOrDefault(c => c.Type == "is_blocked")?.Value ?? "false");
            PermissionResolver.BuildPermissions(
                Int32.Parse(claimsList.FirstOrDefault(c => c.Type == "permissions")?.Value ?? "0")
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new UnknownException("Error applying claims: " + e.Message);
        }
    }
}