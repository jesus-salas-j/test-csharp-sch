using System.Collections.Generic;
using test_csharp_sch_application.respositoryContracts;

namespace test_csharp_sch_infrastructure
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private Dictionary<string, string> _storedCredentials;

        public AuthenticationRepository()
        {
            _storedCredentials = new Dictionary<string, string>();
            _storedCredentials.Add("username", "password");
            _storedCredentials.Add("test", "testpwd");
        }

        public bool AreRegisteredCredentials(string username, string password)
        {
            string storedPassword;

            if (_storedCredentials.TryGetValue(username, out storedPassword))
            {
                return password.Equals(storedPassword);
            }

            return false;
        }
    }
}
