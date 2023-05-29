namespace Samba.Data
{
    /// <summary>
    /// User data holder class for file parsing
    /// </summary>
    public class User
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

        public User()
        {
            Username = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            MainGroup = string.Empty;
            AuxGroups = string.Empty;
            Id = string.Empty;
            Password = string.Empty;
        }

        public User(string username, string lastName, string firstName, string mainGroup, string auxGroups, string id, string password)
        {
            Username = username;
            LastName = lastName;
            FirstName = firstName;
            MainGroup = mainGroup;
            AuxGroups = auxGroups;
            Id = id;
            Password = password;
        }
    }
}
