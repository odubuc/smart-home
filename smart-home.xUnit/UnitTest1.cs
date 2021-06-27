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
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UnitTest1()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        /*
        [Theory]
        [InlineData("GET")]
        public void Test1(string method)
        {
            // Arange
            //var request = new HttpRequestMessage(new HttpMethod(method), "/weatherIndoor");

            // Act
            //var response = await _client.SendAsync(request);

            // Assert
            //response.EnsureSuccessStatusCode();
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }*/

        [Theory]
        [InlineData("GET")]
        public async Task WeatherIndoor(string method) 
        {
            WeatherIndoor data = await _client.GetFromJsonAsync<WeatherIndoor>("weatherIndoor");
            Assert.IsType<WeatherIndoor>(data);
        }

        [Theory]
        [InlineData("GET")]
        public async Task WeatherOutdoor(string method)
        {
            WeatherOutdoor[] data = await _client.GetFromJsonAsync<WeatherOutdoor[]>("weatherOutdoor");
            Assert.IsType<WeatherOutdoor[]>(data);
        }
    }
}
