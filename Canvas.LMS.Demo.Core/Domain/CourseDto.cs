using System;
using System.Collections.Generic;

namespace Canvas.LMS.Demo.Core.Domain
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AccountId { get; set; }

        public DateTime StartAt { get; set; }

        public int? GradingStandardId  { get; set; }

        public bool IsPublic { get; set; }

        public string CourseCode { get; set; }

        public string DefaultView { get; set; }

        public int RootAccountId { get; set; }

        public int EnrollmentTermId { get; set; }

        public DateTime? EndAt { get; set; }

        public bool PublicSyllabus { get; set; }

        public bool IsPublicToAuthUsers { get; set; }

        public bool ApplyAssignmentGroupWeights { get; set; }

        public CalendarDto Calendar { get; set; }

        public List<CourseEnrollmentDto> Enrollments { get; set; }

        public bool HideFinalGrades { get; set; }

        public string WorkflowState { get; set; }

        public bool RestrictEnrollmentsToCourseDates { get; set; }
    }
}