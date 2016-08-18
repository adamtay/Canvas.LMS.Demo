using System;
using System.Collections.Generic;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Tests.Builders
{
    public class CreateAssignmentRequestDtoBuilder
    {
        private readonly CourseDto _course;
        private readonly string _name;
        private readonly int _position;
        private readonly List<AssignmentSubmissionType> _submissionTypes;
        private readonly List<AssignmentExtensionType> _allowedExtensions;
        private readonly bool _peerReviews;
        private readonly bool _automaticPeerReviews;
        private readonly bool _notifyOfUpdate;
        private readonly int _groupCategoryId;
        private readonly bool _gradeGroupStudentsIndividually;
        private readonly decimal _pointsPossible;
        private readonly AssignmentGradingType _gradingType;
        private readonly DateTime _dueAt;
        private readonly DateTime _lockAt;
        private readonly DateTime _unlockAt;
        private readonly string _description;
        private readonly int _assignmentGroupId;
        private readonly bool _published;
        private readonly bool _omitFromFinalGrade;

        public CreateAssignmentRequestDtoBuilder(CourseDto course)
        {
            _course = course;
            _name = "Writing your first If-Statement";
            _position = 0;
            _submissionTypes = new List<AssignmentSubmissionType>
            {
                AssignmentSubmissionType.ExternalTool,
            };
            _allowedExtensions = new List<AssignmentExtensionType>
            {
                AssignmentExtensionType.Docx,
                AssignmentExtensionType.Pdf,
                AssignmentExtensionType.Ppt
            };
            _peerReviews = true;
            _automaticPeerReviews = true;
            _notifyOfUpdate = true;
            _groupCategoryId = 0;
            _gradeGroupStudentsIndividually = false;
            _pointsPossible = 50;
            _gradingType = AssignmentGradingType.Points;
            _dueAt = DateTime.UtcNow.AddDays(5);
            _lockAt = _dueAt;
            _unlockAt = DateTime.UtcNow.AddDays(1);
            _description = "Assignment for writing your first If-Statement";
            _assignmentGroupId = 1;
            _published = true;
            _omitFromFinalGrade = true;
        }

        public CreateAssignmentRequestDto Build()
        {
            return new CreateAssignmentRequestDto
            {
                CourseId = _course.Id,
                Name = _name,
                Position = _position,
                SubmissionTypes = _submissionTypes,
                AllowedExtensions = _allowedExtensions,
                PeerReviews = _peerReviews,
                AutomaticPeerReviews = _automaticPeerReviews,
                NotifyOfUpdate = _notifyOfUpdate,
                GroupCategoryId = _groupCategoryId,
                GradeGroupStudentsIndividually = _gradeGroupStudentsIndividually,
                PointsPossible = _pointsPossible,
                GradingType = _gradingType,
                DueAt = _dueAt,
                LockAt = _lockAt,
                UnlockAt = _unlockAt,
                Description = _description,
                AssignmentGroupId = _assignmentGroupId,
                Published = _published,
                OmitFromFinalGrade = _omitFromFinalGrade
            };
        }
    }
}