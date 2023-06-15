namespace Samba.Command.Types
{
    /// <summary>
    /// Type of commands for a single user
    /// </summary>
    public enum UserCommandType
    {
        Add,
        Remove,
        Update,
        ChangePassword,
        ChangeGroup,
        Undefined
    }
}
