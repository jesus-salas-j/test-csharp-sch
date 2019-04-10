using test_csharp_sch_application.contracts;
using test_csharp_sch_domain.entities;
using test_csharp_sch_domain.enums;

namespace test_csharp_sch_application.services
{
    public class Navigation : INavigation
    {
        public bool IsAccessAllowed(User user, Pages page)
        {
            switch (user.Role)
            {
                case Roles.PAGE_1:
                    return page == Pages.PAGE_1;
                case Roles.PAGE_2:
                    return page == Pages.PAGE_2;
                case Roles.PAGE_3:
                    return page == Pages.PAGE_3;
                default:
                    return false;
            }
        }
    }
}
