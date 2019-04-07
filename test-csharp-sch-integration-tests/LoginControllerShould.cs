using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_mvc;

namespace test_csharp_sch_integration_tests
{
    [TestClass]
    public class LoginControllerShould
    {
        private static HttpClient _client;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
            WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
        }

        [TestMethod]
        public void login_view_is_accessible()
        {
            HttpResponseMessage response = _client.GetAsync("/Login/Signin").Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void user_is_logged_in()
        {
            string credentials = "username=test&password=testpwd";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin", 
                new StringContent(
                    content: credentials, 
                    encoding: Encoding.UTF8, 
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void user_login_rejected_for_bad_credentials()
        {
            string credentials = "username=fruit&password=apple";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}



