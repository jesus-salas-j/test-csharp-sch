using test_csharp_sch_application.contracts;
using test_csharp_sch_application.respositoryContracts;

namespace test_csharp_sch_application.services
{
    public class Authenticator : IAuthenticator
    {
        private IAuthenticationRepository _authenticatorRepository;

        public Authenticator(IAuthenticationRepository authenticatorRepository)
        {
            _authenticatorRepository = authenticatorRepository;
        }

        public bool IsAllowed(string username, string password)
        {
            return _authenticatorRepository.AreRegisteredCredentials(username, password);
        }
    }
}
