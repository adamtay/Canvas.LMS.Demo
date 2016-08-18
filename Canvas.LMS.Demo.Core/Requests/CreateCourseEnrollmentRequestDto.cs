namespace Canvas.LMS.Demo.Core.Requests
{
    public class CreateCourseEnrollmentRequestDto
    {
        public string UserId { get; set; }

        public string CourseId { get; set; }

        public EnrollmentType EnrollmentType { get; set; }

        public EnrollmentState EnrollmentState { get; set; }
    }

    public enum EnrollmentType
    {
        StudentEnrollment,
        TeacherEnrollment
    }

    public enum EnrollmentState
    {
        Active,
        Invited,
        Inactive
    }
}