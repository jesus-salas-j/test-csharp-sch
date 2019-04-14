using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_csharp_sch_mvc;

namespace test_csharp_sch_integration_tests
{
    [TestClass]
    public class AppControllerShould
    {
        private HttpClient _client;

        [TestInitialize]
        public void BeforeEach()
        {
            WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
        }

        [TestMethod]
        public void Show_page_1_when_user_with_role_page1_is_logged()
        {
            LoginInUserWithPage1Role();
            HttpResponseMessage response = _client.GetAsync("/App/Page1").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 1"));
        }
        
        [TestMethod]
        public void Show_page_2_when_user_with_role_page2_is_logged()
        {
            LoginInUserWithPage2Role();
            HttpResponseMessage response = _client.GetAsync("/App/Page2").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 2"));
        }

        [TestMethod]
        public void Show_page_3_when_user_with_role_page3_is_logged()
        {
            LoginInUserWithPage3Role();
            HttpResponseMessage response = _client.GetAsync("/App/Page3").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 3"));
        }

        [TestMethod]
        public void Forbid_access_to_page_X_when_user_with_role_Y_is_logged()
        {
            LoginInUserWithPage1Role();
            HttpResponseMessage response = _client.GetAsync("/App/Page3").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }


        private void LoginInUserWithPage1Role()
        {
            string credentials = "username=username&password=password";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;
        }

        private void LoginInUserWithPage2Role()
        {
            string credentials = "username=test&password=testpwd";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;
        }

        private void LoginInUserWithPage3Role()
        {
            string credentials = "username=fruit&password=apple";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;
        }
    }
}
