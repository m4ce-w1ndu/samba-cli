using Samba.Command.Local.User;
using Samba.Configuration;
using Samba.Data.Attributes;

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
        public override LocalCommand Generate(IDataEntity entity)
        {
            // We need to retrieve the instance of a configuration
            // file reader
            var config = ConfigReader.GetInstance();

            // Executable path
            var exec = config.Executable;
            
            if (entity is Data.User user)
            {
                var args = user.GenerateLocalCommand();
                if (args is null) return new(new("", ""));

                return new(new(exec, args));
            }

            return default;
        }
    }
}
