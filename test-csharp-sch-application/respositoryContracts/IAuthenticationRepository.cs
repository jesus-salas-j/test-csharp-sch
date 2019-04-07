namespace test_csharp_sch_application.respositoryContracts
{
    public interface IAuthenticationRepository
    {
        bool AreRegisteredCredentials(string username, string password);
    }
}
