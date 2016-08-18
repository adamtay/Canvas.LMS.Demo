using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Builders;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.Requests;
using Canvas.LMS.Demo.Core.RestClient;
using RestSharp;

namespace Canvas.LMS.Demo.Core
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
        public async Task<UserDto> CreateUser(CreateUserRequestDto userRequestDto)
        {
            if (userRequestDto == null) throw new ArgumentNullException(nameof(userRequestDto));

            string resource = "accounts/self/users";
            RestRequest restRequest = new RestRequest(resource, Method.POST);

            Dictionary<string, string> requestParameters = new UserRequestParametersBuilder(userRequestDto).Build();
            restRequest.AddRequestParameters(requestParameters);

            return await _canvasClient.Execute<UserDto>(restRequest);
        }
    }
}