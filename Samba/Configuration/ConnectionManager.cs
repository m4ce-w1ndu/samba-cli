using Novell.Directory.Ldap;
using Samba.Common;

namespace Samba.Configuration
{
    /// <summary>
    /// LDAP connection manager
    /// </summary>
    public class ConnectionManager
    {
        private static readonly ConnectionManager? instance;

        private readonly LdapConnection m_Connection;

        /// <summary>
        /// LDAP port
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// LDAP Domain (AD Domain as FQDN)
        /// </summary>
        public string Domain { get; private set; }

        /// <summary>
        /// Administrator username
        /// </summary>
        public string Username { get; private set; }

        private ConnectionManager()
        {
            m_Connection = new LdapConnection();
            Domain = string.Empty;
            Username = string.Empty;
        }
        
        /// <summary>
        /// Returns the instance of the connection manager
        /// </summary>
        public static ConnectionManager GetInstance()
        {
            if (instance is null) return new ConnectionManager();
            return instance;
        }

        /// <summary>
        /// Connects and returns a reference to the <see cref="LdapConnection"/>
        /// </summary>
        /// <param name="domain">Domain to bind</param>
        /// <param name="username">Administrator's username</param>
        /// <param name="password">Administrator's password</param>
        /// <param name="port">Optional port parameter</param>
        /// <returns><see cref="LdapConnection"/> reference</returns>
        public LdapConnection Connect(string domain, string username, string password, int port = Constants.DEFAULT_LDAP_PORT)
        {
            Domain = domain;
            Username = username;

            if (m_Connection.Connected) return m_Connection;
            m_Connection.Connect(domain, port);
            m_Connection.Bind($"{domain}\\{username}", password);

            return m_Connection;
        }
    }
}
