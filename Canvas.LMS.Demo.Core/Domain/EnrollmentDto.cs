using System;

namespace Canvas.LMS.Demo.Core.Domain
{
    public class EnrollmentDto
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string SISCourseId { get; set; }

        public string CourseIntegrationId { get; set; }

        public int CourseSectionId { get; set; }

        public string SectionIntegrationId { get; set; }

        public string SISSectionId { get; set; }

        public string EnrollmentState { get; set; }

        public bool LimitPrivilegesToCourseSection { get; set; }

        public int SISImportId { get; set; }

        public int RootAccountId { get; set; }

        public string Type { get; set; }

        public string AssociatedUserId { get; set; }

        public string Role { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public DateTime LastActivityAt { get; set; }

        public int TotalActivityTime { get; set; }

        public string HtmlUrl { get; set; }

        public string Grades { get; set; }

        public decimal ComputedCurrentScore { get; set; }

        public decimal ComputedFinalScore { get; set; }

        public string ComputedCurrentGrade { get; set; }

        public string ComputedFinalGrade { get; set; }

        public bool MultipleGradingPeriodsEnabled { get; set; }

        public bool TotalsForAllGradingPeriodOption { get; set; }

        public string CurrentGradingPeriodTitle { get; set; }

        public int CurrentGradingPeriodId { get; set; }

        public decimal CurrentPeriodComputedCurrentScore { get; set; }

        public decimal CurrentPeriodComputedFinalScore { get; set; }

        public string CurrentPeriodComputedCurrentGrade { get; set; }

        public string CurrentPeriodComputedFinalGrade { get; set; }
    }
}