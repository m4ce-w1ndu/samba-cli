namespace Samba.Command
{
    /// <summary>
    /// Command interface to implement on every type of command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Holds the execution result of the issued command
        /// </summary>
        public ExecutionResultState ExecutionResult { get; init; }

        /// <summary>
        /// Runs the command
        /// </summary>
        public void Run();
    }

    /// <summary>
    /// Possible command states
    /// </summary>
    public enum ExecutionResultState
    {
        Ok,
        Error,
        Stopped
    }
}
