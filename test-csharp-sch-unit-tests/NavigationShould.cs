using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_application.services;
using test_csharp_sch_application.contracts;
using test_csharp_sch_domain.entities;
using test_csharp_sch_domain.enums;

namespace test_csharp_sch_unit_tests
{
    [TestClass]
    public class NavigationShould
    {
        private static INavigation _navigation;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
            _navigation = new Navigation();
        }

        [TestMethod]
        public void Allow_role_page1_access_page1_view()
        {
            User user = new User(Roles.PAGE_1);
            Page page = new Page("Page 1");

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, page);

            Assert.IsTrue(userIsAllowedToAccessPage);
        }

        [TestMethod]
        public void Allow_role_page2_access_page2_view()
        {
            User user = new User(Roles.PAGE_2);
            Page page = new Page("Page 2");

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, page);

            Assert.IsTrue(userIsAllowedToAccessPage);
        }

        [TestMethod]
        public void Allow_role_page3_access_page3_view()
        {
            User user = new User(Roles.PAGE_3);
            Page page = new Page("Page 3");

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, page);

            Assert.IsTrue(userIsAllowedToAccessPage);
        }
    }
}
