using System;
using System.Configuration;
using System.Threading.Tasks;
using RestSharp;

namespace Canvas.LMS.Demo.Core.RestClient
{
    /// <summary>
    /// Responsible for consuming the Canvas API.
    /// </summary>
    public class CanvasClient
    {
        private readonly IRestClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasClient"/> class.
        /// </summary>
        public CanvasClient()
        {
            string baseUrlAddress = ConfigurationManager.AppSettings["canvas:BaseUrlAddress"];
            _client = new RestSharp.RestClient(baseUrlAddress);
        }

        /// <summary>
        /// Executes the specified rest request.
        /// </summary>
        public async Task<T> Execute<T>(RestRequest restRequest, UserType userType = UserType.Admin) where T : new()
        {
            if (restRequest == null) throw new ArgumentNullException(nameof(restRequest));

            AppendRequestHeaders(restRequest, userType);

            IRestResponse<T> response = await _client.ExecuteTaskAsync<T>(restRequest);
            if (response.StatusCode.IsSuccessStatusCode())
            {
                return response.Data;
            }

            const string message = "Error retrieving response from the Canvas API. Check the inner details for more information.";
            throw new ApplicationException(message, new Exception(response.Content));
        }

        /// <summary>
        /// Executes the specified rest request.
        /// </summary>
        public async Task<IRestResponse> Execute(RestRequest restRequest, UserType userType = UserType.Admin)
        {
            if (restRequest == null) throw new ArgumentNullException(nameof(restRequest));

            AppendRequestHeaders(restRequest, userType);

            IRestResponse response = await _client.ExecuteTaskAsync(restRequest);
            if (response.StatusCode.IsSuccessStatusCode())
            {
                return response;
            }

            const string message = "Error retrieving response from the Canvas API. Check the inner details for more information.";
            throw new ApplicationException(message, new Exception(response.Content));
        }

        private static void AppendRequestHeaders(RestRequest restRequest, UserType userType)
        {
            restRequest.AddHeader("Authorization", userType.ToBearerToken());
            restRequest.AddHeader("Content-Type", "application-json; charset=utf-8");
        }
    }
}