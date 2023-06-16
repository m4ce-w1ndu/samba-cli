using Samba.Data.Attributes;
using Samba.Command.Types;
using Samba.Command.Local;
using Samba.Data;

namespace SambaTest
{
    public class Commands
    {
        [Fact]
        public void GenerateCommand_UserAdd()
        {
            var user = new User("testuser", "Rossi", "Mario", "Domain Admins", "Managers", "CF", "testpasswd", UserCommandType.Add);
            // Create an instance of the command generator
            var generator = new LocalGenerator("TestData/sample.cfg");
            var result = generator.Generate(user);
        }
    }
}
