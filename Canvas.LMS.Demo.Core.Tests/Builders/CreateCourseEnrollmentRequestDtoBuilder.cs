using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Tests.Builders
{
    public class CreateCourseEnrollmentRequestDtoBuilder
    {
        private readonly UserDto _user;
        private readonly CourseDto _course;
        private readonly EnrollmentType _enrollmentType;
        private readonly EnrollmentState _enrollmentState;

        public CreateCourseEnrollmentRequestDtoBuilder(UserDto user, CourseDto course)
        {
            _user = user;
            _course = course;
            _enrollmentType = EnrollmentType.StudentEnrollment;
            _enrollmentState = EnrollmentState.Active;
        }

        public CreateCourseEnrollmentRequestDto Build()
        {
            return new CreateCourseEnrollmentRequestDto
            {
                UserId = _user.Id.ToString(),
                CourseId = _course.Id.ToString(),
                EnrollmentType = _enrollmentType,
                EnrollmentState = _enrollmentState
            };
        }
    }
}