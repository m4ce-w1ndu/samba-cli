namespace Samba.Command.Local
{
    /// <summary>
    /// Local program to execute
    /// </summary>
    /// <param name="Executable">Executable path</param>
    /// <param name="Arguments">Program arguments</param>
    public record class Program(string Executable, string Arguments);

    /// <summary>
    /// Local command parameters
    /// </summary>
    public class LocalCommandParameters : CommandParameters
    {
        /// <summary>
        /// Standard output data
        /// </summary>
        public string StandardOutput { get; init; }
        
        /// <summary>
        /// Standard error data
        /// </summary>
        public string StandardError { get; init; }

        /// <summary>
        /// Result data
        /// </summary>
        public ExecutionResult Result { get; init; }

        public LocalCommandParameters(string standardOutput, string standardError, ExecutionResult result)
        {
            StandardOutput = standardOutput;
            StandardError = standardError;
            Result = result;
        }
    }

    /// <summary>
    /// Command to run locally on the system. It uses the
    /// Process facility to run the command as a new process
    /// on the local system
    /// </summary>
    public class LocalCommand : Command
    {
        /// <summary>
        /// Program information
        /// </summary>
        public Program Program { get; init; }

        /// <summary>
        /// Standard output of the command
        /// </summary>
        public string StandardOutput { get; private set; }

        /// <summary>
        /// Standard error of the command
        /// </summary>
        public string StandardError { get; private set; }

        /// <summary>
        /// Construct a new Local command
        /// </summary>
        /// <param name="program"></param>
        public LocalCommand(Program program) : base(ExecutionResult.Undefined)
        {
            Program = program;
            StandardOutput = string.Empty;
            StandardError = string.Empty;
        }

        /// <summary>
        /// Sets the status of a process
        /// </summary>
        /// <param name="parameters">Parameters for status settings</param>
        /// <exception cref="ArgumentException">May be thrown if the command type is not valid</exception>
        public override void SetStatus(CommandParameters parameters)
        {
            if (parameters is LocalCommandParameters p)
            {
                StandardOutput = p.StandardOutput;
                StandardError = p.StandardError;
                Result = p.Result;
            }
            else
            {
                throw new ArgumentException($"{nameof(parameters)} is not valid for this context");
            }
        }
    }
}
