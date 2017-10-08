namespace ApiTemplate.UnitTests
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.TestHost;
    using System;
    using System.Net.Http;
    using System.Reflection;
    using Xunit;

    public class IntegrationTests
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public IntegrationTests()
        {
            // Arrange
            this.server = new TestServer(new WebHostBuilder()
                .UseStartup<TestStartup>()
                .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory));
                //.UseEnvironment("IntegrationTest"));

            //var hostBuilder = new WebHostBuilder()
            //    .Configure(app =>
            //    {
            //        app.Run(async context =>
            //        {
            //            await context.Response.WriteAsync("Test response");
            //        });
            //    });

            //this.server = new TestServer(hostBuilder);

            this.client = this.server.CreateClient();
            this.client.BaseAddress = new Uri("http://localhost:5000");
        }

        [Fact]
        public async void Resopnds_With_Empty_Body_When_Db_Is_Empty()
        {
            var response = await this.client.GetAsync("/api/values");

            var content = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            //Assert.True(response.IsSuccessStatusCode);
        }
    }
}
