using test_csharp_sch_domain.entities;

namespace test_csharp_sch_application.contracts
{
    public interface IUsers
    {
        User GetUser(string username);
    }
}
