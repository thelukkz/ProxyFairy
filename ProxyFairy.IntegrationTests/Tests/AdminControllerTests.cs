using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ProxyFairy.IntegrationTests.Tests
{
    public class AdminControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AdminControllerTests(CustomWebApplicationFactory<ProxyFairy.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_LoginPageWithRedirect()
        {
            //arrange
            var url = "/admin/users";
            var redirectUrl = "http://localhost/Account/Login?ReturnUrl=%2Fadmin%2Fusers";
            var client = _factory.CreateClient(
                new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            //act
            var response = await client.GetAsync(url);

            //assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.StartsWith(redirectUrl, response.Headers.Location.OriginalString);
        }
    }
}
