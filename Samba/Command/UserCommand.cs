using Samba.Data;
using Samba.Configuration;
using Samba.Common;
using Novell.Directory.Ldap;

// Samba constants
using Const = Samba.Common.Constants;

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
            var log = CommonUtilities.Logger;

            var config = CFGReader.GetInstance();

            using var connection = new LdapConnection();
            
            try
            {
                connection.Connect(config.Domain, Const.DEFAULT_LDAP_PORT);
                connection.Bind(config.AdminUser, config.AdminPasswd);

                var searchBase = StringUtilities.GetSearchBaseFromFQDN(config.Domain);
                var searchFilter = $"(&(objectCategory=user)(sAMAccountName={username}))";
                var searchResponse = connection.Search(searchBase, LdapConnection.ScopeSub, searchFilter, null, false);
                return searchResponse.HasMore();
            }
            catch (LdapException e)
            {
                log.Error("severe problem detected! LDAP search failure: {@Message}.", e.Message);
                Environment.Exit(Const.EXIT_FAILURE);
            }

            return false;
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
