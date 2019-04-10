using System.Collections.Generic;
using System.Linq;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_domain.entities;

namespace test_csharp_sch_infrastructure
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private IEnumerable<Credentials> _storedCredentials;

        public AuthenticationRepository()
        {
            _storedCredentials = new List<Credentials>
            {
                new Credentials (username: "username", password: "password"),
                new Credentials (username: "test", password: "testpwd"),
                new Credentials (username: "fruit", password: "apple")
            };
        }

        public bool AreRegistered(Credentials credentials)
        {
            return _storedCredentials.Any(x => 
                x.Username.Equals(credentials.Username) &&
                x.Password.Equals(credentials.Password));
        }
    }
}
