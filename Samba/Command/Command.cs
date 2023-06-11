namespace Samba.Command
{
    public enum ExecutionResult
    { 
        Ok,
        Error,
        Stopped,
        Undefined
    }

    /// <summary>
    /// Command is an executable entity which can be executed
    /// in different complex contexts, such as local (directly),
    /// remote (via SSH) or LDAP (using the LDAP protocol)
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Result of the execution of a command
        /// </summary>
        public ExecutionResult Result { get; protected set; }

        /// <summary>
        /// Sets the command status
        /// </summary>
        public abstract void SetStatus(CommandParameters parameters);

        /// <summary>
        /// Sets the command execution result
        /// </summary>
        /// <param name="result">Execution result of this command</param>
        public Command(ExecutionResult result)
        {
            Result = result;
        }
    }

    /// <summary>
    /// Provides a unique abstract class for passing data
    /// into the command
    /// </summary>
    public abstract class CommandParameters { }
}
