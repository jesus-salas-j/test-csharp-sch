using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using test_csharp_sch_application.contracts;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_application.services;

namespace test_csharp_sch_unit_tests
{
    [TestClass]
    public class AuthenticatorShould
    {
        private static IAuthenticator _autenticator;
        private static Mock<IAuthenticationRepository> _authenticationRepository;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
            _authenticationRepository = new Mock<IAuthenticationRepository>();
            _autenticator = new Authenticator(_authenticationRepository.Object);
        }

        [TestMethod]
        public void allow_access_to_registered_user()
        {
            string username = "username";
            string password = "password";
            _authenticationRepository
                .Setup(x => x.AreRegisteredCredentials(username, password))
                .Returns(true);

            Assert.IsTrue(_autenticator.IsAllowed(username, password));
        }

        [TestMethod]
        public void not_allow_access_to_not_registered_user()
        {
            string username = "username";
            string password = "password";
            _authenticationRepository
                .Setup(x => x.AreRegisteredCredentials(username, password))
                .Returns(false);

            Assert.IsFalse(_autenticator.IsAllowed(username, password));
        }
    }
}
