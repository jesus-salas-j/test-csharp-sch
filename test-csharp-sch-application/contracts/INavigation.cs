using test_csharp_sch_domain.entities;

namespace test_csharp_sch_application.contracts
{
    public interface INavigation
    {
        bool IsAccessAllowed(User user, Page page);
    }
}
