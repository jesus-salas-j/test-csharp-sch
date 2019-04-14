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
        public void Allow_access_to_login_view()
        {
            HttpResponseMessage response = _client.GetAsync("/Login/Signin").Result;

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void Log_in_user()
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
        public void Reject_user_login_for_bad_credentials()
        {
            string credentials = "username=abcdefgh&password=12345";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void Log_out_user()
        {
            LoginUserWithPage1Role();
            HttpResponseMessage logoutResponse = _client.GetAsync("/Login/Logout").Result;
            HttpResponseMessage pageResponse = _client.GetAsync("/App/Page1").Result;

            Assert.AreEqual(HttpStatusCode.Forbidden, pageResponse.StatusCode);
        }

        [TestMethod]
        public void Log_in_user_and_redirect_to_his_default_page()
        {
            HttpResponseMessage message = LoginUserWithPage2Role();
            string content = message.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 2"));
        }


        private void LoginUserWithPage1Role()
        {
            string credentials = "username=username&password=password";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;
        }

        private HttpResponseMessage LoginUserWithPage2Role()
        {
            string credentials = "username=test&password=testpwd";
            return _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;
        }

    }
}



