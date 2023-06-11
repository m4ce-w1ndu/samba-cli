using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samba.Command.Local
{
    public class LocalCommand : ICommand
    {
        public ExecutionResultState ExecutionResult { get; private set; }

        /// <summary>
        /// Executable file path
        /// </summary>
        public string Executable { get; init; }

        /// <summary>
        /// Executable arguments
        /// </summary>
        public string Arguments { get; init; }

        /// <summary>
        /// Standard output of the command
        /// </summary>
        public string StandardOutput { get; private set; }

        /// <summary>
        /// Standard error of the command
        /// </summary>
        public string StandardError { get; private set; }

        public virtual void Run()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Construct a new local command
        /// </summary>
        /// <param name="executable">Executable path (or name, if executable is in PATH)</param>
        /// <param name="arguments">Executable arguments</param>
        public LocalCommand(string executable, string arguments)
        {
            Executable = executable;
            Arguments = arguments;
            StandardOutput = string.Empty;
            StandardError = string.Empty;
        }
    }
}
