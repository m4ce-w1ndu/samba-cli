namespace Samba.Command
{
    /// <summary>
    /// Runs a command of the specified type
    /// </summary>
    /// <typeparam name="CmdType"></typeparam>
    public abstract class Runner<CmdType> where CmdType : Command
    {
        /// <summary>
        /// Runs the command
        /// </summary>
        public abstract void Run();
    }
}
