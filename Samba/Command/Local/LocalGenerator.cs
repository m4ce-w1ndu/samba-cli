namespace Samba.Command.Local
{
    /// <summary>
    /// Generates local commands 
    /// </summary>
    public class LocalGenerator : Generator
    {
        /// <summary>
        /// Commands options used to generate this new command
        /// </summary>
        public CommandOptions Options { get; set; }

        /// <summary>
        /// Creates an instance of a new command generator
        /// </summary>
        /// <param name="options"></param>
        public LocalGenerator(CommandOptions options)
        {
            Options = options;
        }

        /// <summary>
        /// Generates a new local command
        /// </summary>
        /// <returns>New generated command</returns>
        public override LocalCommand Generate()
        {
            throw new NotImplementedException();
        }
    }
}
