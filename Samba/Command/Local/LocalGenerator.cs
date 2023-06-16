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
        private ConfigReader config;

        public LocalGenerator()
        {
            config = ConfigReader.GetInstance();
        }

        public LocalGenerator(string cfgFilePath)
        {
            config = ConfigReader.GetInstance(cfgFilePath);
        }

        /// <summary>
        /// Generates a new local command
        /// </summary>
        /// <returns>New generated command</returns>
        public override LocalCommand Generate(IDataEntity entity)
        {
            // Executable path
            var exec = config.Executable;
            
            if (entity is Data.User user)
            {
                var args = user.GenerateLocalCommand(config);
                if (args is null) return new(new("", ""));

                return new(new(exec, args));
            }

            return default;
        }
    }
}
