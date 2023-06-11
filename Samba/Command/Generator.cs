namespace Samba.Command
{
    /// <summary>
    /// Generates a new command to be run
    /// </summary>
    public abstract class Generator
    {
        /// <summary>
        /// Generates a new command based on a specific set of options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public abstract Command Generate(CommandOptions options);
    }
}
