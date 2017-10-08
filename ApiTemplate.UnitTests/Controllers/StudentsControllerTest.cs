namespace ApiTemplate.UnitTests.Controllers
{
    using ApiTemplate.Controllers;
    using ApiTemplate.Models;
    using ApiTemplate.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class StudentsControllerTest
    {
        [Fact]
        public async Task GetStudents_ReturnsOkResult_WithAListOfStudents()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            mockRepo.Setup(repo => repo.GetStudents()).Returns(Task.FromResult(GetTestStudents()));
            var controller = new StudentsController(mockRepo.Object);

            // Act
            var result = await controller.GetStudents();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Student>>(
                viewResult.Value);

            Assert.Equal(2, model.Count());
        }

        private IEnumerable<Student> GetTestStudents()
        {
            return new List<Student>
            {
                new Student() { FirstMidName = "Jack", LastName = "Mistrz", EnrollmentDate = new DateTime(2002, 09, 01) }
                ,new Student() { FirstMidName = "Kon Dupi", LastName = "Dupi", EnrollmentDate = new DateTime(2016, 12, 30) }
            };
        }
    }
}
