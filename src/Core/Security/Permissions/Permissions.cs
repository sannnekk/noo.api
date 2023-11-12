namespace noo.api.Core.Security.Permissions;

public enum Permissions
{
    #region Works
    SolveWorks = 1 << 0,
    CheckWorks = 1 << 1,
    CreateWorks = 1 << 2,
    #endregion

    #region Materials
    ReadMaterials = 1 << 3,
    CreateMaterials = 1 << 4,
    #endregion

    #region Users
    ReadUsers = 1 << 5,
    CreateUsers = 1 << 6,
    #endregion
}