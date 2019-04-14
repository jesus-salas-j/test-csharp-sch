using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_domain.entities;
using test_csharp_sch_infrastructure;

namespace test_csharp_sch_integration_tests
{
    [TestClass]
    public class UsersRepositoryShould
    {
        private static IUsersRepository _usersRepository;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
            _usersRepository = new UsersRepository();
        }

        [TestMethod]
        public void Find_existent_user()
        {
            string existingUsername = "username";

            User user = _usersRepository.GetUser(existingUsername);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Do_not_find_inexistent_user()
        {
            string existingUsername = "inexistentUser";

            User user = _usersRepository.GetUser(existingUsername);

            Assert.IsNull(user);
        }
    }
}
