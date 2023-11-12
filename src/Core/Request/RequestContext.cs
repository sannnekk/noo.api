using System.Security.Claims;
using noo.api.Core.Security.Permissions;

namespace noo.api.Core.Request;

public struct RequestContext
{
    public string? UserId { get; private set; }
    public string? UserRole { get; private set; }
    public bool IsBlocked { get; private set; }
    public readonly PermissionResolver PermissionResolver { get; }

    public RequestContext(string? userId, string? userRole, bool isBlocked, int permissions)
    {
        UserId = userId;
        UserRole = userRole;
        IsBlocked = isBlocked;
        PermissionResolver = new PermissionResolver(permissions);
    }

    public static RequestContext Empty()
    {
        return new RequestContext(null, null, false, 0);
    }

    public static RequestContext FromClaims(IEnumerable<Claim> claims)
    {
        var userId = claims.FirstOrDefault(c => c.Type == "user_id")?.Value;
        var userRole = claims.FirstOrDefault(c => c.Type == "user_role")?.Value;
        var isBlocked = bool.Parse(claims.FirstOrDefault(c => c.Type == "is_blocked")?.Value ?? "false");
        var permissions = int.Parse(claims.FirstOrDefault(c => c.Type == "permissions")?.Value ?? "0");

        return new RequestContext(userId, userRole, isBlocked, permissions);
    }

    public Dictionary<string, string> ToDictionary()
    {
        return new()
        {
            { "user_id", UserId ?? "" },
            { "user_role", UserRole ?? "" },
            { "is_blocked", IsBlocked.ToString() },
            { "permissions", PermissionResolver.Permissions.ToString() }
        };
    }
}