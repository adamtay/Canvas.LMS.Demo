using System;
using System.Collections.Generic;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Builders
{
    /// <summary>
    /// Responsible for building the <see cref="CreateCourseEnrollmentRequestDto"/> request parameters.
    /// </summary>
    public class CourseEnrollmentParametersBuilder
    {
        private readonly CreateCourseEnrollmentRequestDto _courseEnrollmentRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseEnrollmentParametersBuilder"/> class.
        /// </summary>
        public CourseEnrollmentParametersBuilder(CreateCourseEnrollmentRequestDto courseEnrollmentRequest)
        {
            if (courseEnrollmentRequest == null) throw new ArgumentNullException(nameof(courseEnrollmentRequest));

            _courseEnrollmentRequest = courseEnrollmentRequest;
        }

        /// <summary>
        /// Builds the request parameters.
        /// </summary>
        public Dictionary<string, string> Build()
        {
            return new Dictionary<string, string>
            {
                {"enrollment[user_id]", _courseEnrollmentRequest.UserId},
                {"enrollment[type]", _courseEnrollmentRequest.EnrollmentType.ToString()},
                {"enrollment[enrollment_state]", _courseEnrollmentRequest.EnrollmentState.ToString()}
            };
        }
    }
}