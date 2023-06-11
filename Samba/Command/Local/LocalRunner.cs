using System;
using System.Diagnostics;

namespace Samba.Command.Local
{
    /// <summary>
    /// Runs a local command
    /// </summaryCmd
    /// <typeparam name="Command">Type of the local command</typeparam>
    public class LocalRunner<Cmd> : Runner<Cmd> where Cmd : LocalCommand
    {
        /// <summary>
        /// Command to run
        /// </summary>
        public Cmd Command { get; set; }

        /// <summary>
        /// Process to be started on OS
        /// </summary>
        private readonly Process m_Process;

        public LocalRunner(Cmd command)
        {
            Command = command;

            // Setup new process
            m_Process = new();

            // Setup startup information
            m_Process.StartInfo.FileName = command.Program.Executable;
            m_Process.StartInfo.Arguments = command.Program.Arguments;

            // Setup events
            m_Process.EnableRaisingEvents = true;
            m_Process.OutputDataReceived += OnOutputDataReceived;
            m_Process.ErrorDataReceived += OnErrorDataReceived;
        }

        /// <summary>
        /// Runs the process on the local system
        /// </summary>
        public override void Run()
        {
            m_Process.Start();
        }

        /// <summary>
        /// This event is raised when the process produces some output
        /// </summary>
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Command.SetStatus(new LocalCommandParameters(e.Data, string.Empty, ExecutionResult.Ok));
            }
        }

        /// <summary>
        /// This event is raised when the process raises any kind of error
        /// </summary>
        private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Command.SetStatus(new LocalCommandParameters(string.Empty, e.Data, ExecutionResult.Error));
            }
        }
    }
}
