using Serilog;
using Serilog.Core;
using System.Text;

namespace Samba.Common
{
    /// <summary>
    /// Contains common utilities
    /// </summary>
    public static class CommonUtilities
    {
        /// <summary>
        /// Project logger instance
        /// </summary>
        public static Logger Logger { get; set; } = new LoggerConfiguration().WriteTo.Console().CreateLogger();
    }

    public static class StringUtilities
    {
        public const char DOMAIN_SEPARATOR = '.';

        public static string NormalizeName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get LDAP search base from domain FQDN
        /// </summary>
        /// <param name="domain">Domain FQDN</param>
        /// <returns>Search base for this domain</returns>
        public static string GetSearchBaseFromFQDN(string domain)
        {
            var sb = new StringBuilder();
            var components = domain.Split(DOMAIN_SEPARATOR);

            foreach (var (component, i) in components.Select((value, i) => (value, i)))
                sb.Append(i < components.Length ? $"dc={component}," : $"dc={component}");

            return sb.ToString();
        }
    }
}
