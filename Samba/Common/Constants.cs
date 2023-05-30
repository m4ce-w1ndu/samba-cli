namespace Samba.Common
{
    /// <summary>
    /// Useful constants for every aspect of this project
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Default users CSV file delimiter
        /// </summary>
        public const string DEFAULT_DELIMITER = ";";

        /// <summary>
        /// Default configuration file path
        /// </summary>
        public const string DEFAULT_CFG_PATH = "/etc/ad/ad.conf";

        /// <summary>
        /// Default LDAP port
        /// </summary>
        public const int DEFAULT_LDAP_PORT = 389;

        /// <summary>
        /// Failure exit code based on Unix standard
        /// </summary>
        public const int EXIT_FAILURE = 1;
    }
}
