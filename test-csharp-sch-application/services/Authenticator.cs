using test_csharp_sch_application.contracts;
using test_csharp_sch_application.respositoryContracts;
using test_csharp_sch_domain.entities;

namespace test_csharp_sch_application.services
{
    public class Authenticator : IAuthenticator
    {
        private IAuthenticationRepository _authenticatorRepository;

        public Authenticator(IAuthenticationRepository authenticatorRepository)
        {
            _authenticatorRepository = authenticatorRepository;
        }

        public bool AreRegistered(Credentials credentials)
        {
            return _authenticatorRepository.AreRegistered(credentials);
        }
    }
}
