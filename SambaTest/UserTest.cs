using Samba.Data;

namespace SambaTest
{
    public class UserTest
    {
        [Fact]
        public void User_LoadFromFile_CorrectFormat()
        {
            const string FILENAME = "users.csv";
            var result = User.LoadFromFile(FILENAME);

            Assert.Equal(2, result.Count);

            // Test for the first line
            // testuser;Test;User;group1;group2;cf;TestPassword
            Assert.Equal("testuser", result[0].Username);
            Assert.Equal("Test", result[0].LastName);
            Assert.Equal("User", result[0].FirstName);
            Assert.Equal("group1", result[0].MainGroup);
            Assert.Equal("group2", result[0].AuxGroups);
            Assert.Equal("cf", result[0].Id);
            Assert.Equal("TestPassword", result[0].Password);

            // Test for the second line
            // testadmin;Test;Admin;group1;group2;cf;TestPassword
            Assert.Equal("testadmin", result[1].Username);
            Assert.Equal("Test", result[1].LastName);
            Assert.Equal("Admin", result[1].FirstName);
            Assert.Equal("group1", result[1].MainGroup);
            Assert.Equal("group2", result[1].AuxGroups);
            Assert.Equal("cf", result[1].Id);
            Assert.Equal("TestPassword", result[1].Password);
        }

        public void User_Exists_Domain()
        {
            const string CFG_FILE = "test.conf";

        }
    }
}