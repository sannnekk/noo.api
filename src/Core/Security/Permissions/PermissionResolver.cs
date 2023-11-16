namespace noo.api.Core.Security.Permissions;

public class PermissionResolver
{
    public int Permissions { get; private set; }

    public PermissionResolver(int permissions)
    {
        this.Permissions = permissions;
    }

    public bool HasPermission(Permissions permission)
    {
        return (Permissions & (int)permission) != 0;
    }

    public void BuildPermissions(int permissions)
    {
        this.Permissions = permissions;
    }

    public void BuildPermissions(IEnumerable<Permissions> permissions)
    {
        foreach (var permission in permissions)
        {
            this.Permissions |= (int)permission;
        }
    }
}