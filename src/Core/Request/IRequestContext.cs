using System.Security.Claims;
using noo.api.Core.Security.Permissions;

namespace noo.api.Core.Request;

public interface IRequestContext
{
    string? UserId { get; }
    string? UserRole { get; }
    bool IsBlocked { get; }
    PermissionResolver PermissionResolver { get; }

    void ApplyClaims(IEnumerable<Claim> claims);
}