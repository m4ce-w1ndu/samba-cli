using Samba.Command.Types;
using Samba.Configuration;
using Samba.Data.Attributes;
using System.Text;
using DataUser = Samba.Data.User;

namespace Samba.Command.Local.User
{
    internal static class LocalUserCommands
    {
        /// <summary>
        /// Generates a user command based on the attribute type
        /// </summary>
        internal static string? GenerateLocalCommand(this DataUser user, ConfigReader? configReader = null)
        {
            var command = typeof(DataUser).GetCustomAttributes(typeof(HasCommand), true)
                                          .Select(a => (HasCommand)a).FirstOrDefault();
            if (command is null || !command.Enabled) return null;

            return user.CommandType switch
            {
                UserCommandType.Add => GenerateAddCommand(user, configReader),
                _ => null
            };
        }

        private static string GenerateAddCommand(DataUser userData, ConfigReader? configReader)
        {
            var cmd = new StringBuilder($"user create {userData.Username} {userData.Password}");
            var config = configReader is null ? ConfigReader.GetInstance() : configReader;

            // Add other settings to command if the fields are populated
            if (!string.IsNullOrEmpty(userData.LastName))
                cmd.Append($@" --surname=""{userData.LastName}"" ");
            if (!string.IsNullOrEmpty(userData.FirstName))
                cmd.Append($@" --given-name=""{userData.FirstName}"" ");

            // Read configuration to get user share directory
            if (!string.IsNullOrEmpty(config.HomeDirectoriesShare))
                cmd.Append($@" --home-directory=""\\\\{config.DefaultDC}\\{config.HomeDirectoriesShare}\\{userData.Username}"" ");
            if (!string.IsNullOrEmpty(config.HomeDriveLetter))
                cmd.Append($@" --home-drive={config.HomeDriveLetter} ");
            if (!string.IsNullOrEmpty(config.ProfilePath))
                cmd.Append($@" --profile-path=""\\\\{config.DefaultDC}\\{config.HomeDirectoriesShare}\\{userData.Username}\\{config.ProfilePath}""");

            return cmd.ToString();
        }
    }
}
