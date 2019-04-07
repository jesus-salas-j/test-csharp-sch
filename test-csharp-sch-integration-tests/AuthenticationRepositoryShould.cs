using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_infrastructure;

namespace test_csharp_sch_integration_tests
{
    [TestClass]
    public class AuthenticationRepositoryShould
    {
        private static IAuthenticationRepository _authenticationRepository;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
            _authenticationRepository = new AuthenticationRepository();
        }

        [TestMethod]
        public void find_default_registered_credentials()
        {
            string username1 = "username";
            string username2 = "test";
            string password1 = "password";
            string password2 = "testpwd";

            bool defaultCredentials1Found =
                _authenticationRepository.AreRegisteredCredentials(username1, password1);
            bool defaultCredentials2Found =
                _authenticationRepository.AreRegisteredCredentials(username2, password2);

            Assert.IsTrue(defaultCredentials1Found);
            Assert.IsTrue(defaultCredentials2Found);
        }

        [TestMethod]
        public void refuse_not_registered_credentials()
        {
            string username = "non-existent username";
            string password = "fake password";

            bool nonExistentCredentialsFound =
                _authenticationRepository.AreRegisteredCredentials(username, password);

            Assert.IsFalse(nonExistentCredentialsFound);
        }
    }
}
