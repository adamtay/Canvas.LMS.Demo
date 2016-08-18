using System;
using System.Collections.Generic;
using System.Configuration;
using RestSharp;

namespace Canvas.LMS.Demo.Core.RestClient
{
    public static class RestRequestExtensionMethods
    {
        public static void AddRequestParameters(this RestRequest restRequest, Dictionary<string, string> requestParameters)
        {
            foreach (KeyValuePair<string, string> requestParameter in requestParameters)
            {
                restRequest.AddParameter(requestParameter.Key, requestParameter.Value);
            }
        }

        public static string ToBearerToken(this UserType userType)
        {
            switch (userType)
            {
                case UserType.Admin:
                    return ConfigurationManager.AppSettings["canvas:AdminBearerToken"];
                case UserType.Teacher:
                    return ConfigurationManager.AppSettings["canvas:TeacherBearerToken"];
                case UserType.Student:
                    return ConfigurationManager.AppSettings["canvas:StudentBearerToken"];
                default:
                    throw new InvalidOperationException($"Unable to resolve bearer token for the user type: {userType}.");
            }
        }
    }
}