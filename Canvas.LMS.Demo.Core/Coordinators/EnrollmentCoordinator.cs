using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Builders;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;
using Canvas.LMS.Demo.Core.RestClient;
using RestSharp;

namespace Canvas.LMS.Demo.Core.Coordinators
{
    /// <summary>
    /// Coordinator for creating and viewing course enrollments.
    /// </summary>
    public class EnrollmentCoordinator
    {
        private readonly CanvasClient _canvasClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentCoordinator"/> class.
        /// </summary>
        public EnrollmentCoordinator()
        {
            _canvasClient = new CanvasClient();
        }

        /// <summary>
        /// Enrolls a user to a course.
        /// </summary>
        public async Task<EnrollmentDto> EnrollUserToCourse(CreateCourseEnrollmentRequestDto courseEnrollmentRequest)
        {
            if (courseEnrollmentRequest == null) throw new ArgumentNullException(nameof(courseEnrollmentRequest));

            string resource = $"courses/{courseEnrollmentRequest.CourseId}/enrollments";
            RestRequest restRequest = new RestRequest(resource, Method.POST);

            Dictionary<string, object> requestParameters = new CourseEnrollmentParametersBuilder(courseEnrollmentRequest).Build();
            restRequest.AddRequestParameters(requestParameters);

            return await _canvasClient.Execute<EnrollmentDto>(restRequest);
        }
    }
}