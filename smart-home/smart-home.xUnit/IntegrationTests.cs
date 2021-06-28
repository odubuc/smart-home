using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using smart_home.Server;
using System.Threading.Tasks;
using System.Net;
using smart_home.Shared;
using System.Net.Http.Json;

namespace smart_home.xUnit
{
    public class IntegrationTests
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public IntegrationTests()
        {
            // Arrange
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.client = this.server.CreateClient();
        }

        /*
        [Theory]
        [InlineData("GET")]
        public void WeatherIndoor_Answer_OK(string method)
        {
            // Arange
            var request = new HttpRequestMessage(new HttpMethod(method), "/weatherIndoor");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        */

        [Fact]
        public async Task WeatherIndoor_Type_IsValid()
        {
            WeatherIndoor data = await this.client.GetFromJsonAsync<WeatherIndoor>("weatherIndoor");
            Assert.IsType<WeatherIndoor>(data);
        }

        [Fact]
        public async Task WeatherOutdoor_Type_IsValid()
        {
            WeatherOutdoor[] data = await this.client.GetFromJsonAsync<WeatherOutdoor[]>("weatherOutdoor");
            Assert.IsType<WeatherOutdoor[]>(data);
        }
    }
}
