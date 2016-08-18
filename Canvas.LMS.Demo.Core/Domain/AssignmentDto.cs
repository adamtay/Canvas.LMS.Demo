using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Canvas.LMS.Demo.Core.Domain
{
    public class AssignmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DueAt { get; set; }

        public DateTime? LockAt { get; set; }

        public DateTime? UnlockAt { get; set; }

        public bool HasOverrides { get; set; }

        public int CourseId { get; set; }

        public string HtmlUrl { get; set; }

        public string SubmissionsDownloadUrl { get; set; }

        public int AssignmentGroupId { get; set; }

        public List<AssignmentExtensionType> AllowedExtensions { get; set; }

        public bool GradeGroupStudentsIndividually { get; set; }

        public bool PeerReviews { get; set; }

        public bool AutomaticPeerReviews { get; set; }

        public int GroupCategoryId { get; set; }

        public int NeedsGradingCount { get; set; }

        public decimal PointsPossible { get; set; }

        public List<AssignmentSubmissionType> SubmissionTypes { get; set; }

        public AssignmentGradingType GradingType { get; set; }

        public bool Published { get; set; }
    }
}