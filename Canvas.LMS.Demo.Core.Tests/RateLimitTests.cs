using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Builders;
using Canvas.LMS.Demo.Core.Requests;
using Canvas.LMS.Demo.Core.RestClient;
using Canvas.LMS.Demo.Core.Tests.Builders;
using NUnit.Framework;
using RestSharp;

namespace Canvas.LMS.Demo.Core.Tests
{
    [TestFixture]
    //[Ignore("Testing API throttling. A pre-flight penalty is added to prevent the API from being flooded")]
    public class RateLimitTests
    {
        private readonly CanvasClient _canvasClient;
        private readonly Stopwatch _stopwatch;

        public RateLimitTests()
        {
            _canvasClient = new CanvasClient();
            _stopwatch = new Stopwatch();
        }

        [Test]
        public void SimulateRateLimitting()
        {
            const int numberOfThreads = 25;

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numberOfThreads; i++)
            {
                tasks.Add(CreateCourseAndLog());
                tasks.Add(GetCoursesListAndLog());
            }

            _stopwatch.Start();
            Task.WhenAll(tasks).Wait();
            _stopwatch.Stop();
        }

        private async Task<IRestResponse> CreateCourseAndLog()
        {
            string resource = "accounts/self/courses";
            RestRequest restRequest = new RestRequest(resource, Method.POST);

            CreateCourseRequestDto createCourseRequest = new CreateCourseRequestDtoBuilder().Build();

            Dictionary<string, object> requestParameters = new CourseRequestParametersBuilder(createCourseRequest).Build();
            restRequest.AddRequestParameters(requestParameters);

            IRestResponse restResponse = await _canvasClient.Execute(restRequest);

            LogRequestRateLimiting(restResponse);
            Console.WriteLine($"Finished create course request: {_stopwatch.Elapsed}");

            return restResponse;
        }

        private async Task<IRestResponse> GetCoursesListAndLog()
        {
            string resource = "courses?per_page=50";
            RestRequest restRequest = new RestRequest(resource, Method.GET);

            IRestResponse restResponse = await _canvasClient.Execute(restRequest);

            LogRequestRateLimiting(restResponse);
            Console.WriteLine($"Finished getting course list request: {_stopwatch.Elapsed}");

            return restResponse;
        }

        private static void LogRequestRateLimiting(IRestResponse restResponse)
        {
            const string requestCostHeader = "X-Request-Cost";
            const string rateLimitRemainingHeader = "X-Rate-Limit-Remaining";
            Console.WriteLine(
                $"Cost of Request: {ExtractHeaderValue(restResponse, requestCostHeader)}. " +
                $"Rate limit remaining: {ExtractHeaderValue(restResponse, rateLimitRemainingHeader)}");
        }

        private static string ExtractHeaderValue(IRestResponse restResponse, string headerName)
        {
            Parameter rateLimitRemainingHeader = restResponse.Headers.First(h => h.Name.Equals(headerName));
            return rateLimitRemainingHeader.Value.ToString();
        }

    }
}