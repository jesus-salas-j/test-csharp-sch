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
            User user = new User("username", "password", Roles.PAGE_1);

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, Pages.PAGE_1);

            Assert.IsTrue(userIsAllowedToAccessPage);
        }

        [TestMethod]
        public void Allow_role_page2_access_page2_view()
        {
            User user = new User("username", "password", Roles.PAGE_2);

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, Pages.PAGE_2);

            Assert.IsTrue(userIsAllowedToAccessPage);
        }

        [TestMethod]
        public void Allow_role_page3_access_page3_view()
        {
            User user = new User("username", "password", Roles.PAGE_3);

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, Pages.PAGE_3);

            Assert.IsTrue(userIsAllowedToAccessPage);
        }

        [TestMethod]
        public void Do_not_allow_role_page_x_access_page_y_view()
        {
            User user = new User("username", "password", Roles.PAGE_2);

            bool userIsAllowedToAccessPage = _navigation.IsAccessAllowed(user, Pages.PAGE_1);

            Assert.IsFalse(userIsAllowedToAccessPage);
        }

        [TestMethod]
        public void Get_first_allowed_page_from_user_role()
        {
            User user = new User("username", "password", Roles.PAGE_2);

            Pages page = _navigation.GetFirstAllowedPageFrom(user.Role);

            Assert.AreEqual(Pages.PAGE_2, page);
        }
    }
}
