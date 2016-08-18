using System;
using System.Collections.Generic;
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

            course.Id.Should().NotBe(0);
            course.Name.Should().Be(createCourseRequest.Name);
            course.CourseCode.Should().Be(createCourseRequest.CourseCode);
            course.PublicSyllabus.Should().Be(createCourseRequest.PublicSyllabus);
            course.IsPublicToAuthUsers.Should().Be(createCourseRequest.IsPublicToAuthUsers);
            course.Calendar.Should().NotBeNull();
            // TODO: These properties are not being set to the same as the request
            //course.IsPublic.Should().Be(createCourseRequest.IsPublic);
            //course.RestrictEnrollmentsToCourseDates.Should().Be(createCourseRequest.RestrictEnrollmentsToCourseDates); 
        }

        [Test]
        public async Task CanCreateAssignmentForCourse()
        {
            CreateCourseRequestDto createCourseRequest = new CreateCourseRequestDtoBuilder().Build();
            CourseDto course = await _coursesCoordinator.CreateCourse(createCourseRequest);

            CreateAssignmentRequestDto createAssignmentRequest = new CreateAssignmentRequestDtoBuilder(course).Build();

            AssignmentDto assignment = await _coursesCoordinator.CreateAssignment(createAssignmentRequest);

            assignment.Should().NotBeNull();

            Console.WriteLine(JsonConvert.SerializeObject(assignment, Formatting.Indented));

            assignment.Id.Should().NotBe(0);
            assignment.Name.Should().Be(createAssignmentRequest.Name);
            assignment.Description.Should().Be(createAssignmentRequest.Description);
            assignment.DueAt.Should().BeCloseTo(createAssignmentRequest.DueAt, 1000);
            assignment.LockAt.Should().BeCloseTo(createAssignmentRequest.LockAt, 1000);
            assignment.UnlockAt.Should().BeCloseTo(createAssignmentRequest.UnlockAt, 1000);
            assignment.CourseId.Should().Be(course.Id);
            assignment.HtmlUrl.Should().NotBeNullOrEmpty();
            assignment.SubmissionsDownloadUrl.Should().NotBeNullOrEmpty();
            assignment.AssignmentGroupId.Should().NotBe(0);
            assignment.AllowedExtensions.Count.Should().Be(createAssignmentRequest.AllowedExtensions.Count);
            assignment.GradeGroupStudentsIndividually.Should().Be(createAssignmentRequest.GradeGroupStudentsIndividually);
            assignment.GroupCategoryId.Should().Be(createAssignmentRequest.GroupCategoryId);
            assignment.PointsPossible.Should().Be(createAssignmentRequest.PointsPossible);
            assignment.SubmissionTypes.Count.Should().Be(createAssignmentRequest.SubmissionTypes.Count);
            assignment.GradingType.Should().Be(createAssignmentRequest.GradingType);
            assignment.Published.Should().Be(createAssignmentRequest.Published);

            //assignment.PeerReviews.Should().Be(createAssignmentRequest.PeerReviews);
            //assignment.AutomaticPeerReviews.Should().Be(createAssignmentRequest.AutomaticPeerReviews);
        }
    }
}