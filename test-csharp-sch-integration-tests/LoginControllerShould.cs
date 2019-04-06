using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_mvc;

namespace test_csharp_sch_integration_tests
{
    [TestClass]
    public class LoginControllerShould
    {
        private static HttpClient client;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
            WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [TestMethod]
        public void login_view_is_accessible()
        {
            HttpResponseMessage response = client.GetAsync("/Login/Signin").Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}



