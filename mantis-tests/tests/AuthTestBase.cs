using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : BaseTest
    {
        [OneTimeSetUp]
        public void SetupLogin()
        {
            app.LoginHelper.Login(new AccountData("administrator", "root"));
        }
    }
}
