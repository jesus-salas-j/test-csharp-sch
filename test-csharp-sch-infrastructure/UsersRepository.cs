using System.Collections.Generic;
using System.Linq;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_domain.entities;
using test_csharp_sch_domain.enums;

namespace test_csharp_sch_infrastructure
{
    public class UsersRepository : IUsersRepository
    {
        private IEnumerable<User> _storedUsers;

        public UsersRepository()
        {
            _storedUsers = new List<User>
            {
                new User (username: "username", password: "password", role: Roles.PAGE_1),
                new User (username: "test", password: "testpwd", role: Roles.PAGE_2),
                new User (username: "fruit", password: "apple", role: Roles.PAGE_3)
            };
        }

        public User GetUser(string username)
        {
            return _storedUsers.FirstOrDefault(x => x.Username.Equals(username));
        }
    }
}
