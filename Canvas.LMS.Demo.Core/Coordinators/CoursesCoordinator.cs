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
    /// Coordinator for accessing course information.
    /// </summary>
    public class CoursesCoordinator
    {
        private readonly CanvasClient _canvasClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesCoordinator"/> class.
        /// </summary>
        public CoursesCoordinator()
        {
            _canvasClient = new CanvasClient();
        }

        /// <summary>
        /// Returns the list of active courses for the current user (based on the authorisation token).
        /// </summary>
        public async Task<IEnumerable<CourseDto>> GetCourses(UserType userType = UserType.Admin)
        {
            RestRequest restRequest = new RestRequest("courses", Method.GET);
            return await _canvasClient.Execute<List<CourseDto>>(restRequest, userType);
        }

        /// <summary>
        /// Returns the list of all users enrolled in the specified course.
        /// </summary>
        public async Task<IEnumerable<UserDto>> GetUsersEnrolledInCourse(int courseId)
        {
            string resource = $"courses/{courseId}/users";
            RestRequest restRequest = new RestRequest(resource, Method.GET);

            return await _canvasClient.Execute<List<UserDto>>(restRequest);
        }

        /// <summary>
        /// Creates a new course.
        /// </summary>
        public async Task<CourseDto> CreateCourse(CreateCourseRequestDto createCourseRequest)
        {
            if (createCourseRequest == null) throw new ArgumentNullException(nameof(createCourseRequest));

            string resource = "accounts/self/courses";
            RestRequest restRequest = new RestRequest(resource, Method.POST);

            Dictionary<string, object> requestParameters = new CourseRequestParametersBuilder(createCourseRequest).Build();
            restRequest.AddRequestParameters(requestParameters);

            return await _canvasClient.Execute<CourseDto>(restRequest);
        }

        /// <summary>
        /// Create a new assignment for the specified course. The assignment is created in the active state.
        /// </summary>
        public async Task<AssignmentDto> CreateAssignment(CreateAssignmentRequestDto createAssignmentRequest)
        {
            if (createAssignmentRequest == null) throw new ArgumentNullException(nameof(createAssignmentRequest));

            string resource = $"courses/{createAssignmentRequest.CourseId}/assignments";
            RestRequest restRequest = new RestRequest(resource, Method.POST);

            Dictionary<string, object> requestParameters = new AssignmentRequestParametersBuilder(createAssignmentRequest).Build();
            restRequest.AddRequestParameters(requestParameters);

            return await _canvasClient.Execute<AssignmentDto>(restRequest);
        }
    }
}