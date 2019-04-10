using test_csharp_sch_application.contracts;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_domain.entities;

namespace test_csharp_sch_application.services
{
    public class Users : IUsers
    {
        private readonly IUsersRepository _usersRepository;

        public Users(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetUser(string username)
        {
            return _usersRepository.GetUser(username);
        }
    }
}
