using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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

        [TestMethod]
        public void user_is_logged_in()
        {
            string credentials = "username=test&password=testpwd";
            HttpResponseMessage response = client.PostAsync("/Login/Signin", 
                new StringContent(
                    content: credentials, 
                    encoding: Encoding.UTF8, 
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}



