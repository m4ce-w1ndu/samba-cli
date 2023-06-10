using Samba.Common;
using System.Diagnostics;

namespace Samba.Command
{
    public class CommandRunner
    {
        /// <summary>
        /// Executable name (or full path)
        /// </summary>
        public string Executable { get; set; }

        /// <summary>
        /// Executable arguments
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// Output of command
        /// </summary>
        public string Output { get; private set; }

        /// <summary>
        /// Error output of command
        /// </summary>
        public string Error { get; private set; }

        public CommandRunner(string executable, string arguments)
        {
            Executable = executable;
            Arguments = arguments;
            Output = string.Empty;
            Error = string.Empty;
        }

        public void Run()
        {
            var process = new Process();
            process.StartInfo.FileName = Executable;
            process.StartInfo.Arguments = Arguments;

            // Enable STDOUT and STDERR redirection with events
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;

            // Setup event handlers
            process.OutputDataReceived += CommandRunner_OutputReceived;
            process.ErrorDataReceived += CommandRunner_ErrorRaised;
            process.Exited += (sender, e) => CommonUtilities.Logger.Information("Exited.");
        }

        /// <summary>
        /// Logs a raised error and terminates the process
        /// </summary>
        /// <param name="sender">Error sender</param>
        /// <param name="e">Error data</param>
        private void CommandRunner_ErrorRaised(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                CommonUtilities.Logger.Error(e.Data);
                Error = e.Data;
            }

            Environment.Exit(Constants.EXIT_FAILURE);
        }

        /// <summary>
        /// Logs the output of the process
        /// </summary>
        /// <param name="sender">Output sender</param>
        /// <param name="e">Output data</param>
        public void CommandRunner_OutputReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                Output = e.Data;
        }
    }
}
