namespace test_csharp_sch_application.contracts
{
    public interface IAuthenticator
    {
        bool IsAllowed(string username, string password);
    }
}
