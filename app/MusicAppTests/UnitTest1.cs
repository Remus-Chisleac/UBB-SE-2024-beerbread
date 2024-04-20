
using app;

namespace MusicAppTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Account testAccount = new Account("alex@bigdick.lol", "sindrila", "!23", "muieMAIU");
            Assert.NotNull(testAccount);
            Assert.Equal("alex@bigdick.lol", testAccount.Email);
        }
       
    }
}