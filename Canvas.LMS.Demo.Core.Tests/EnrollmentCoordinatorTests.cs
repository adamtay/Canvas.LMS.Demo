using System;
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
    public class EnrollmentCoordinatorTests
    {
        private UsersCoordinator _usersCoordinator;
        private CoursesCoordinator _coursesCoordinator;
        private EnrollmentCoordinator _enrollmentCoordinator;

        [SetUp]
        public void SetUp()
        {
            _usersCoordinator = new UsersCoordinator();
            _coursesCoordinator = new CoursesCoordinator();
            _enrollmentCoordinator = new EnrollmentCoordinator();
        }

        [Test]
        public async Task CanEnrollUserToACourse()
        {
            UserDto user = await CreateUser();
            CourseDto course = await CreateCourse();

            CreateCourseEnrollmentRequestDto courseEnrollmentRequest = new CreateCourseEnrollmentRequestDtoBuilder(user, course).Build();

            EnrollmentDto enrollment = await _enrollmentCoordinator.EnrollUserToCourse(courseEnrollmentRequest);

            enrollment.Should().NotBeNull();

            Console.WriteLine(JsonConvert.SerializeObject(enrollment, Formatting.Indented));
        }

        private async Task<UserDto> CreateUser()
        {
            CreateUserRequestDto createUserRequest = new CreateUserRequestDtoBuilder().Build();
            return await _usersCoordinator.CreateUser(createUserRequest);
        }

        private async Task<CourseDto> CreateCourse()
        {
            CreateCourseRequestDto createCourseRequest = new CreateCourseRequestDtoBuilder().Build();
            return await _coursesCoordinator.CreateCourse(createCourseRequest);
        }
    }
}