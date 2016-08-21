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
    /// Coordinator for accessing user information.
    /// </summary>
    public class UsersCoordinator
    {
        private readonly CanvasClient _canvasClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersCoordinator"/> class.
        /// </summary>
        public UsersCoordinator()
        {
            _canvasClient = new CanvasClient();
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        public async Task<UserDto> CreateUser(CreateUserRequestDto createUserRequest)
        {
            if (createUserRequest == null) throw new ArgumentNullException(nameof(createUserRequest));

            string resource = "accounts/self/users";
            RestRequest restRequest = new RestRequest(resource, Method.POST);

            Dictionary<string, object> requestParameters = new UserRequestParametersBuilder(createUserRequest).Build();
            restRequest.AddRequestParameters(requestParameters);

            return await _canvasClient.Execute<UserDto>(restRequest);
        }

        /// <summary>
        /// Gets the list of active courses for the specified user.
        /// </summary>
        public async Task<IEnumerable<CourseDto>> GetCourses(int userId)
        {
            string resource = $"users/{userId}/courses";
            RestRequest restRequest = new RestRequest(resource, Method.GET);

            return await _canvasClient.Execute<List<CourseDto>>(restRequest);
        }
    }
}