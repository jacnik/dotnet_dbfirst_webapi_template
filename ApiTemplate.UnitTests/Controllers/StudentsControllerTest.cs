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

        [Fact]
        public async Task GetStudent_ReturnsNotFound_WhenIdIsNotValid()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            mockRepo.Setup(repo => repo.GetStudent(12)).Returns(Task.FromResult(GetEmptyStudent()));
            var controller = new StudentsController(mockRepo.Object);

            // Act
            var result = await controller.GetStudent(12);

            // Assert
            var notFoundRequestResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddStudent_ReturnsBadRequestResult_WhenStudentParameterIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<ISchoolRepository>();
            var testStudent = GetTestStudent();
            mockRepo.Setup(repo => repo.AddStudent(testStudent)).Returns(Task.FromResult(GetEmptyInt()));
            var controller = new StudentsController(mockRepo.Object);

            // Act
            var result = await controller.AddStudent(testStudent);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        private Student GetEmptyStudent() => null;

        private Student GetTestStudent() =>
            new Student() { Id = 1, FirstMidName = "Jack", LastName = "Mistrz", EnrollmentDate = new DateTime(2002, 09, 01) };

        private IEnumerable<Student> GetTestStudents()
        {
            return new List<Student>
            {
                new Student() { Id = 1, FirstMidName = "Jack", LastName = "Mistrz", EnrollmentDate = new DateTime(2002, 09, 01) }
                ,new Student() { Id = 2, FirstMidName = "Kon Dupi", LastName = "Dupi", EnrollmentDate = new DateTime(2016, 12, 30) }
            };
        }

        private int? GetEmptyInt() => null;
    }
}
