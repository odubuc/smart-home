using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using smart_home.Server;
using System.Threading.Tasks;
using System.Net;
using smart_home.Shared;
using System.Net.Http.Json;
using System;
using FluentAssertions;

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

        [Theory]
        [InlineData("GET")]
        public async void WeatherIndoor_Answer_OK(string method)
        {
            // Arange
            var request = new HttpRequestMessage(new HttpMethod(method), "/weatherIndoor");

            // Act
            var response = await this.client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WeatherIndoor_Type_IsValid()
        {
            WeatherIndoor data = await this.client.GetFromJsonAsync<WeatherIndoor>("weatherIndoor");
            Assert.IsType<WeatherIndoor>(data);
        }

        [Theory]
        [InlineData("GET")]
        public async void WeatherOutdoor_Answer_OK(string method)
        {
            // Arange
            var request = new HttpRequestMessage(new HttpMethod(method), "/weatherOutdoor");

            // Act
            var response = await this.client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WeatherOutdoor_Type_IsValid()
        {
            WeatherOutdoor[] data = await this.client.GetFromJsonAsync<WeatherOutdoor[]>("weatherOutdoor");
            Assert.IsType<WeatherOutdoor[]>(data);
        }

        [Fact]
        public async Task AirExchanger_InMemory_State()
        {
            AirExchangerState actual = await this.client.GetFromJsonAsync<AirExchangerState>("airExchanger");
            Assert.IsType<AirExchangerState>(actual);

            var rng = new Random();

            actual.State = State.ON;
            actual.OnTimeRemainingMinutes = rng.Next(0, 60);

            await this.client.PutAsJsonAsync<AirExchangerState>("airExchanger", actual);

            AirExchangerState expected = await this.client.GetFromJsonAsync<AirExchangerState>("airExchanger");
            Assert.IsType<AirExchangerState>(expected);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
