using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using test_csharp_sch_application.contracts;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_application.services;
using test_csharp_sch_domain.entities;

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
            Credentials credentials = new Credentials("username", "password");
             
            _authenticationRepository
                .Setup(x => x.AreRegistered(credentials))
                .Returns(true);

            Assert.IsTrue(_autenticator.AreRegistered(credentials));
        }

        [TestMethod]
        public void not_allow_access_to_not_registered_user()
        {
            Credentials credentials = new Credentials("username", "password");

            _authenticationRepository
                .Setup(x => x.AreRegistered(credentials))
                .Returns(false);

            Assert.IsFalse(_autenticator.AreRegistered(credentials));
        }
    }
}
