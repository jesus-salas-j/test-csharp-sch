using System.Net.Http;
using System.Text;
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
        public void show_page_1_when_user_is_logged()
        {
            LoginIn();
            HttpResponseMessage response = _client.GetAsync("/App/Page1").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 1"));
        }
        
        [TestMethod]
        public void show_page_2_when_user_is_logged()
        {
            LoginIn();
            HttpResponseMessage response = _client.GetAsync("/App/Page2").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 2"));
        }

        [TestMethod]
        public void show_page_3_when_user_is_logged()
        {
            LoginIn();
            HttpResponseMessage response = _client.GetAsync("/App/Page3").Result;
            string content = response.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(content.Contains("Page 3"));
        }

        private void LoginIn()
        {
            string credentials = "username=test&password=testpwd";
            HttpResponseMessage response = _client.PostAsync("/Login/Signin",
                new StringContent(
                    content: credentials,
                    encoding: Encoding.UTF8,
                    mediaType: "application/x-www-form-urlencoded"))
                .Result;
        }
    }
}
