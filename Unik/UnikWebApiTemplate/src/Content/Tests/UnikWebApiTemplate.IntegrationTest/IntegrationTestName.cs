using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using UnikWebApiTemplate.API;
using UnikWebApiTemplate.API.Models;
using Xunit;

namespace UnikWebApiTemplate.IntegrationTest
{
    public class IntegrationTestName : IClassFixture<WebApplicationFactory<Startup>>
    {
        public IntegrationTestName(
            WebApplicationFactory<Startup> factory
            )
        {
            _Factory = factory;
        }

        private readonly WebApplicationFactory<Startup> _Factory;

        [Fact]
        public async void IntegrationTestCanCreateTest()
        {
            const string Expected = "Test";

            var client = _Factory.CreateClient();

            var response = await client.PostAsJsonAsync("/api/test", new TestDto
            {
                Name = Expected
            });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = JsonConvert.DeserializeObject<TestDto>(await response.Content.ReadAsStringAsync());
            Assert.Equal(Expected, content.Name);
        }
    }
}
