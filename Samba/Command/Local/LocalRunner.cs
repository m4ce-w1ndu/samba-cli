namespace Samba.Command.Local
{
    /// <summary>
    /// Runs a local command
    /// </summary>
    /// <typeparam name="Command">Type of the local command</typeparam>
    public class LocalRunner<Command> where Command : LocalCommand
    {
    }
}
