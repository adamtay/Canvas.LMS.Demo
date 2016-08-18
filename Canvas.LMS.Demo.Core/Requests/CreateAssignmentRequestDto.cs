using System;
using System.Collections.Generic;
using Canvas.LMS.Demo.Core.Domain;

namespace Canvas.LMS.Demo.Core.Requests
{
    public class CreateAssignmentRequestDto
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the submission types.
        /// </summary>
        /// <remarks>
        /// Unless the assignment is allowing online submissions, the array should only have one element.
        /// </remarks>
        public List<AssignmentSubmissionType> SubmissionTypes { get; set; }

        public List<AssignmentExtensionType> AllowedExtensions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the assignment allows peer reviews.
        /// </summary>
        /// <remarks>
        /// If submission_types does not include external_tool, discussion_topic, online_quiz, or on_paper, 
        /// Peer reviews will be false overwriting what was sent as part of the request.
        /// </remarks>
        public bool PeerReviews { get; set; }

        public bool AutomaticPeerReviews { get; set; }

        public bool NotifyOfUpdate { get; set; }

        public int GroupCategoryId { get; set; }

        public bool GradeGroupStudentsIndividually { get; set; }

        public decimal PointsPossible { get; set; }

        public AssignmentGradingType GradingType { get; set; }

        public DateTime DueAt { get; set; }

        public DateTime LockAt { get; set; }

        public DateTime UnlockAt { get; set; }

        public string Description { get; set; }

        public int AssignmentGroupId { get; set; }

        public bool Published { get; set; }

        public bool OmitFromFinalGrade { get; set; }
    }
}