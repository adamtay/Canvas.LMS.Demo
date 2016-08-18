using System;
using System.Collections.Generic;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Builders
{
    /// <summary>
    /// Responsible for building the <see cref="CreateCourseRequestDto"/> request parameters.
    /// </summary>
    public class CourseRequestParametersBuilder
    {
        private readonly CreateCourseRequestDto _createCourseRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRequestParametersBuilder"/> class.
        /// </summary>
        public CourseRequestParametersBuilder(CreateCourseRequestDto createCourseRequest)
        {
            if (createCourseRequest == null) throw new ArgumentNullException(nameof(createCourseRequest));

            _createCourseRequest = createCourseRequest;
        }

        /// <summary>
        /// Builds the request parameters.
        /// </summary>
        public Dictionary<string, object> Build()
        {
            return new Dictionary<string, object>
            {
                {"course[name]", _createCourseRequest.Name},
                {"course[course_code]", _createCourseRequest.CourseCode},
                {"course[start_at]", _createCourseRequest.StartAt.ToString("o")},
                {"course[end_at]", _createCourseRequest.EndAt?.ToString("o")},
                {"course[is_public]", _createCourseRequest.IsPublic.ToString()},
                {"course[is_public_to_auth_users]", _createCourseRequest.IsPublicToAuthUsers.ToString()},
                {"course[public_syllabus]", _createCourseRequest.PublicSyllabus.ToString()},
                {"course[public_description]", _createCourseRequest.PublicDescription},
                {"course[allow_wiki_comments]", _createCourseRequest.AllowWikiComments.ToString()},
                {"course[allow_student_forum_attachments]", _createCourseRequest.AllowStudentForumAttachments.ToString()},
                {"course[open_enrollment]", _createCourseRequest.OpenEnrollment.ToString()},
                {"course[self_enrollment]", _createCourseRequest.SelfEnrollment.ToString()},
                {"course[restrict_enrollments_to_course_dates]", _createCourseRequest.RestrictEnrollmentsToCourseDates.ToString()},
                {"offer", _createCourseRequest.Offer.ToString()}
            };
        }
    }
}