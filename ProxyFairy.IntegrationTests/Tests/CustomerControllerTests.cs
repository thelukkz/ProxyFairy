using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ProxyFairy.IntegrationTests.Tests
{
    public class CustomerControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CustomerControllerTests(CustomWebApplicationFactory<ProxyFairy.Startup> factory)
        {
            _client = factory.CreateClient();
            _factory = factory;
        }

        //TODO: this test should be changed in future
        [Fact]
        public async Task Get_CustomerPage()
        {
            //arrange
            var url = "/customer";

            //act
            var response = await _client.GetAsync(url);

            //assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
