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
        internal static string? GenerateLocalCommand(this DataUser user)
        {
            var command = typeof(DataUser).GetCustomAttributes(typeof(UserCommand), true)
                                          .Select(a => (UserCommand)a).FirstOrDefault();
            if (command is null) return null;

            return command.Type switch
            {
                UserCommandType.Add => GenerateAddCommand(user),
                _ => null
            };
        }

        private static string GenerateAddCommand(DataUser userData)
        {
            var cmd = new StringBuilder($"user create {userData.Username} {userData.Password}");

            // Add other settings to command if the fields are populated
            if (!string.IsNullOrEmpty(userData.LastName))
                cmd.Append($@" --surname=""{userData.LastName}"" ");
            if (!string.IsNullOrEmpty(userData.FirstName))
                cmd.Append($@" --given-name=""{userData.FirstName}"" ");

            // Read configuration to get user share directory
            var config = ConfigReader.GetInstance();
            if (!string.IsNullOrEmpty(config.HomeDirectoriesShare))
                cmd.Append($@" --home-directory=""\\\\{config.DefaultDC}\\{config.HomeDirectoriesShare}\\{userData.Username} ");
            if (!string.IsNullOrEmpty(config.HomeDriveLetter))
                cmd.Append($@" --home-drive={config.HomeDriveLetter} ");
            if (!string.IsNullOrEmpty(config.ProfilePath))
                cmd.Append($@" --profile-path=""\\\\{config.DefaultDC}\\{config.HomeDirectoriesShare}\\{userData.Username}\\{config.ProfilePath}""");

            return cmd.ToString();
        }
    }
}
