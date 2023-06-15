using Samba.Command.Types;

namespace Samba.Data.Attributes
{
    /// <summary>
    /// User command attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public class UserCommand : Attribute
    {
        /// <summary>
        /// Command enabled
        /// </summary>
        public bool Enabled { get; init; }

        /// <summary>
        /// Commmand type
        /// </summary>
        public UserCommandType Type { get; init; }

        public UserCommand(bool enabled, UserCommandType type = UserCommandType.Undefined)
        {
            Enabled = enabled;
            Type = type;
        }
    }
}
