using Samba.Data;
using Samba.Configuration;
using System.Text.RegularExpressions;

namespace Samba.Command
{
    public class UserCommand
    {
        /// <summary>
        /// Checks if a user exists in the domain
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns>true if exists, false otherwise</returns>
        public static bool IsExistingUser(string username)
        {
            var config = CFGReader.GetInstance();
            var runner = new CommandRunner(config.Executable, "user list");
            var regex = new Regex($@"\b{username}\b");
            return regex.IsMatch(runner.Output);
        }

        /// <summary>
        /// Checks if a user exists in the domain
        /// </summary>
        /// <param name="userdata"><see cref="User"/>User's data</param>
        /// <returns>true if exists, false otherwise</returns>
        public static bool IsExistingUser(User userdata)
        {
            return IsExistingUser(userdata.Username);
        }
    }
}
