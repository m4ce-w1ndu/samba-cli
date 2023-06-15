using IniParser;
using Samba.Common;

namespace Samba.Configuration
{
    public class ConfigReader
    {
        /// <summary>
        /// Instance of this class
        /// </summary>
        private static readonly ConfigReader? instance;

        /// <summary>
        /// Instance of the parser
        /// </summary>
        private readonly IniDataParser parser;

        /// <summary>
        /// Current path to configuration file
        /// </summary>
        public string File { get; private set; }

        /// <summary>
        /// Content of the configuration file as text
        /// </summary>
        public string FileText { get; private set; }

        /// <summary>
        /// Domain name (FQDN)
        /// </summary>
        public string Domain { get; private set; }

        /// <summary>
        /// NETBIOS Domain Name (Workgroup-style NT domain name)
        /// </summary>
        public string NETBIOSDomain { get; private set; }

        /// <summary>
        /// Default domain controller FQDN
        /// </summary>
        public string DefaultDC { get; private set; }

        /// <summary>
        /// Path to home directories share
        /// </summary>
        public string HomeDirectoriesPath { get; private set; }

        /// <summary>
        /// Share path for home directories
        /// </summary>
        public string HomeDirectoriesShare { get; private set; }

        /// <summary>
        /// Home drive letter
        /// </summary>
        public string HomeDriveLetter { get; private set; }

        /// <summary>
        /// User profile path (must be in the home dir share)
        /// </summary>
        public string ProfilePath { get; private set; }

        /// <summary>
        /// Group pool path
        /// </summary>
        public string GroupPoolPath { get; private set; }

        /// <summary>
        /// Owner group of home directories share
        /// </summary>
        public string GroupPoolOwner { get; private set; }

        /// <summary>
        /// User name of administrator
        /// </summary>
        public string AdminUser { get; private set; }

        /// <summary>
        /// Password of administrator
        /// </summary>
        public string AdminPasswd { get; private set; }

        /// <summary>
        /// Samba executable path
        /// </summary>
        public string Executable { get; private set; }

        private ConfigReader(string filepath)
        {
            File = filepath;
            FileText = System.IO.File.ReadAllText(File);
            Domain = string.Empty;
            NETBIOSDomain = string.Empty;
            DefaultDC = string.Empty;
            HomeDirectoriesPath = string.Empty;
            HomeDirectoriesShare = string.Empty;
            HomeDriveLetter = string.Empty;
            ProfilePath = string.Empty;
            GroupPoolPath = string.Empty;
            GroupPoolOwner = string.Empty;
            AdminUser = string.Empty;
            AdminPasswd = string.Empty;
            Executable = string.Empty;
            parser = new IniDataParser();
            ReadData();
        }

        public static ConfigReader GetInstance(string filepath)
        {
            if (instance is null) return new ConfigReader(filepath);
            return instance;
        }

        public static ConfigReader GetInstance()
        {
            if (instance is null) return new ConfigReader(Constants.DEFAULT_CFG_PATH);
            return instance;
        }

        /// <summary>
        /// Reload current configuration
        /// </summary>
        public void ReloadConfig()
        {
            ReadData();
        }

        /// <summary>
        /// Reloads a new configuration
        /// </summary>
        /// <param name="filepath">Path to configuration file</param>
        public void ReloadConfig(string filepath)
        {
            File = filepath;
            FileText = System.IO.File.ReadAllText(File);
            ReadData();
        }

        private void ReadData()
        {
            var data = parser.Parse(FileText);
            Domain = data["AD"]["domain_fqdn"];
            NETBIOSDomain = data["AD"]["domain_nt"];
            DefaultDC = data["AD"]["default_dc_fqdn"];
            HomeDirectoriesPath = data["AD"]["home_dirs_path"];
            HomeDirectoriesShare = data["AD"]["home_dirs_share"];
            HomeDriveLetter = data["AD"]["home_drive_letter"];
            ProfilePath = data["AD"]["profile_path"];
            GroupPoolPath = data["AD"]["grp_pool_path"];
            GroupPoolOwner = data["AD"]["grp_pool_owner"];
            AdminUser = data["AD"]["admin_user"];
            AdminPasswd = data["AD"]["admin_passwd"];
            Executable = data["AD"]["executable"];
        }
    }
}
