using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_domain.entities;
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
        public void Find_default_registered_credentials()
        {
            Credentials credentials1 = new Credentials("username", "password");
            Credentials credentials2 = new Credentials("test", "testpwd");
            
            Assert.IsTrue(_authenticationRepository.AreRegistered(credentials1));
            Assert.IsTrue(_authenticationRepository.AreRegistered(credentials2));
        }

        [TestMethod]
        public void Refuse_not_registered_credentials()
        {
            Credentials credentials = new Credentials("inexistentUsername", "anyPassword");
            
            Assert.IsFalse(_authenticationRepository.AreRegistered(credentials));
        }
    }
}
