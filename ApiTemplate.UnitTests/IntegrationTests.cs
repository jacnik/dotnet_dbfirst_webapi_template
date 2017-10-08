namespace ApiTemplate.UnitTests
{
    using ApiTemplate.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
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
                .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
                .UseEnvironment("IntegrationTest"));

            this.client = this.server.CreateClient();
        }

        [Fact]
        public async void Resopnds_With_Empty_List_When_Db_Is_Empty()
        {
            // Act
            var response = await this.client.GetAsync("/api/students");

            // Assert
            response.EnsureSuccessStatusCode(); // It Equivalent to: Assert.True(response.IsSuccessStatusCode);

            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<List<Student>>(content);

            Assert.Empty(responseData);
        }

        [Fact]
        public async void Resopnds_With_Url_For_Posted_Resource()
        {
            // Arrange
            var student = new Student() { FirstMidName = "Jack", LastName = "Mistrz", EnrollmentDate = new DateTime(2002, 09, 01) };

            // Act
            var response = await this.client.PostAsJsonAsync("/api/students", student);

            // Assert
            response.EnsureSuccessStatusCode(); // It Equivalent to: Assert.True(response.IsSuccessStatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("/api/students/", content);

            // Asert that response is valid Uri
            var resourceUri = new Uri(client.BaseAddress, content);
            Assert.NotNull(resourceUri);
        }
    }
}
