using System;

namespace Canvas.LMS.Demo.Core.Requests
{
    public class CreateCourseRequestDto
    {
        public string Name { get; set; }

        public string CourseCode { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public bool IsPublic { get; set; }

        public bool IsPublicToAuthUsers { get; set; }

        public bool PublicSyllabus { get; set; }

        public string PublicDescription { get; set; }

        public bool AllowWikiComments { get; set; }

        public bool AllowStudentForumAttachments { get; set; }

        public bool OpenEnrollment { get; set; }

        public bool SelfEnrollment { get; set; }

        public bool RestrictEnrollmentsToCourseDates { get; set; }

        public bool Offer { get; set; }
    }
}