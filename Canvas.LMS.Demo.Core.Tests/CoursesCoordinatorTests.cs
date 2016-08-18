using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;
using Canvas.LMS.Demo.Core.Tests.Builders;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Canvas.LMS.Demo.Core.Tests
{
    [TestFixture]
    public class CoursesCoordinatorTests
    {
        private CoursesCoordinator _coursesCoordinator;

        [SetUp]
        public void SetUp()
        {
            _coursesCoordinator = new CoursesCoordinator();
        }

        [Test]
        public async Task CanGetCourses()
        {
            IEnumerable<CourseDto> courses = await _coursesCoordinator.GetCourses(UserType.Teacher);
            courses.Should().NotBeNullOrEmpty();
            Console.WriteLine(JsonConvert.SerializeObject(courses, Formatting.Indented));
        }

        [Test]
        public async Task CanCreateCourse()
        {
            CreateCourseRequestDto createCourseRequest = new CreateCourseRequestDtoBuilder().Build();

            CourseDto course = await _coursesCoordinator.CreateCourse(createCourseRequest);

            course.Should().NotBeNull();
            Console.WriteLine(JsonConvert.SerializeObject(course, Formatting.Indented));
        }
    }
}