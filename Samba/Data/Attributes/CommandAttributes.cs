using Samba.Command.Types;

namespace Samba.Data.Attributes
{
    /// <summary>
    /// User command attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HasCommand : Attribute
    {
        /// <summary>
        /// Command enabled
        /// </summary>
        public bool Enabled { get; init; }

        public HasCommand(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
