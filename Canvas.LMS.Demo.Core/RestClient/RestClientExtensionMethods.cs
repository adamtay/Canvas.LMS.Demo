using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using RestSharp;

namespace Canvas.LMS.Demo.Core.RestClient
{
    public static class RestClientExtensionMethods
    {
        public static void AddRequestParameters(this RestRequest restRequest, Dictionary<string, object> requestParameters)
        {
            foreach (KeyValuePair<string, object> requestParameter in requestParameters)
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

        public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
        {
            int numericResponse = (int)responseCode;
            return numericResponse >= 200
                && numericResponse <= 399;
        }
    }
}