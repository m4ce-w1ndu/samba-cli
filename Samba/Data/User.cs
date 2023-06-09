﻿using FileHelpers;
using Samba.Command.Types;
using Samba.Common;
using Samba.Data.Attributes;

namespace Samba.Data
{
    /// <summary>
    /// User data holder class for file parsing
    /// </summary>
    [DelimitedRecord(Constants.DEFAULT_DELIMITER)]
    [HasCommand(true)]
    public class User : IDataEntity
    {
        /// <summary>
        /// Username of this AD user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Last Name of this AD user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First Name of this AD user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Main group for this AD user
        /// </summary>
        public string MainGroup { get; set; }

        /// <summary>
        /// Secondary group for this AD user. Multiple users can be added
        /// by using the internal field separator as specified in the documentation
        /// </summary>
        public string AuxGroups { get; set; }

        /// <summary>
        /// ID of this AD user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Password of this AD user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Associated command type
        /// </summary>
        public UserCommandType CommandType { get; private set; }

        public User()
        {
            Username = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            MainGroup = string.Empty;
            AuxGroups = string.Empty;
            Id = string.Empty;
            Password = string.Empty;
            CommandType = UserCommandType.Undefined;
        }

        public User(string username, string lastName, string firstName, string mainGroup, string auxGroups, string id, string password, UserCommandType commandType = UserCommandType.Undefined)
        {
            Username = username;
            LastName = lastName;
            FirstName = firstName;
            MainGroup = mainGroup;
            AuxGroups = auxGroups;
            Id = id;
            Password = password;
            CommandType = commandType;
        }

        /// <summary>
        /// Reads and parses input CSV user file automatically
        /// </summary>
        /// <param name="filePath">Path to user file</param>
        /// <returns>A list of <see cref="User"/> objects</returns>
        public static List<User> LoadFromFile(string filePath)
        {
            var engine = new FileHelperEngine(typeof(User));
            var result = engine.ReadFile(filePath).Select(r => (r as User)!).ToList();
            return result ??= new List<User>();
        }
    }
}
