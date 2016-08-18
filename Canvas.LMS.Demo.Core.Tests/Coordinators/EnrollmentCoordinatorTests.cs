using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Coordinators;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;
using Canvas.LMS.Demo.Core.Tests.Builders;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Canvas.LMS.Demo.Core.Tests.Coordinators
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
            
            IEnumerable<UserDto> enrolledUsersInCourse = await _coursesCoordinator.GetUsersEnrolledInCourse(course.Id);
            enrolledUsersInCourse.Any(u => u.Id == user.Id).Should().BeTrue();

            IEnumerable<CourseDto> enrolledCoursesForUser = await _usersCoordinator.GetCourses(user.Id);
            enrolledCoursesForUser.Any(c => c.Id == course.Id).Should().BeTrue();
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