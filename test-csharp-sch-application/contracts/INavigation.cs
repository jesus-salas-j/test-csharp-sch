using test_csharp_sch_domain.entities;
using test_csharp_sch_domain.enums;

namespace test_csharp_sch_application.contracts
{
    public interface INavigation
    {
        bool IsAccessAllowed(User user, Pages page);
        Pages GetFirstAllowedPageFrom(Roles role);
    }
}
