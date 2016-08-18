using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Builders
{
    /// <summary>
    /// Responsible for building the <see cref="CreateAssignmentRequestDto"/> request parameters.
    /// </summary>
    public class AssignmentRequestParametersBuilder
    {
        private readonly CreateAssignmentRequestDto _createAssignmentRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentRequestParametersBuilder"/> class.
        /// </summary>
        public AssignmentRequestParametersBuilder(CreateAssignmentRequestDto createAssignmentRequest)
        {
            if (createAssignmentRequest == null) throw new ArgumentNullException(nameof(createAssignmentRequest));

            _createAssignmentRequest = createAssignmentRequest;
        }

        /// <summary>
        /// Builds the request parameters.
        /// </summary>
        public Dictionary<string, object> Build()
        {
            return new Dictionary<string, object>
            {
                {"assignment[name]", _createAssignmentRequest.Name},
                {"assignment[position]", _createAssignmentRequest.Position.ToString()},
                {"assignment[submission_types]", ToSubmissionTypeString(_createAssignmentRequest.SubmissionTypes)},
                {"assignment[allowed_extensions]", ToAllowedExtensionString(_createAssignmentRequest.AllowedExtensions)},
                {"assignment[peer_reviews]", _createAssignmentRequest.PeerReviews.ToString()},
                {"assignment[automatic_peer_reviews]", _createAssignmentRequest.AutomaticPeerReviews.ToString()},
                {"assignment[notify_of_update]", _createAssignmentRequest.NotifyOfUpdate.ToString()},
                {"assignment[group_category_id]", _createAssignmentRequest.GroupCategoryId.ToString()},
                {"assignment[grade_group_students_individually]", _createAssignmentRequest.GradeGroupStudentsIndividually.ToString()},
                {"assignment[points_possible]", _createAssignmentRequest.PointsPossible.ToString(CultureInfo.CurrentCulture)},
                {"assignment[grading_type]", _createAssignmentRequest.GradingType.ToCanvasString()},
                {"assignment[due_at]", _createAssignmentRequest.DueAt.ToString("o")},
                {"assignment[lock_at]", _createAssignmentRequest.LockAt.ToString("o")},
                {"assignment[unlock_at]", _createAssignmentRequest.UnlockAt.ToString("o")},
                {"assignment[description]", _createAssignmentRequest.Description},
                {"assignment[assignment_group_id]", _createAssignmentRequest.AssignmentGroupId.ToString()},
                {"assignment[published]", _createAssignmentRequest.Published.ToString()},
                {"assignment[omit_from_final_grade]", _createAssignmentRequest.OmitFromFinalGrade.ToString()}
            };
        }

        private static string ToSubmissionTypeString(IEnumerable<AssignmentSubmissionType> submissionTypes)
        {
            return string.Join(", ", submissionTypes.Select(t => t.ToCanvasString()));
        }

        private static string ToAllowedExtensionString(IEnumerable<AssignmentExtensionType> allowedExtenstions)
        {
            return string.Join(", ", allowedExtenstions);
        }
    }
}