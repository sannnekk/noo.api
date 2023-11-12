namespace noo.api.Core.Security.Permissions;

public class PermissionResolver
{
    public int Permissions { get; }

    public PermissionResolver(int permissions)
    {
        this.Permissions = permissions;
    }

    public bool HasPermission(Permissions permission)
    {
        return (Permissions & (int)permission) != 0;
    }

    public Dictionary<Permissions, bool> ParsePermissions()
    {
        var result = new Dictionary<Permissions, bool>();

        foreach (Permissions permission in Enum.GetValues(typeof(Permissions)))
        {
            result.Add(permission, HasPermission(permission));
        }

        return result;
    }

    public static int BuildPermissions(Dictionary<Permissions, bool> permissions)
    {
        var result = 0;
        foreach (var permission in permissions)
        {
            if (permission.Value)
            {
                result |= (int)permission.Key;
            }
            else
            {
                result &= ~(int)permission.Key;
            }
        }

        return result;
    }
}