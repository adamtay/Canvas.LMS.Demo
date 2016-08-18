using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Canvas.LMS.Demo.Core.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssignmentGradingType
    {
        PassFail,
        Percent,
        LetterGrade,
        GpaScale,
        Points
    }

    public static class AssignmentGradingTypeExtensionMethods
    {
        public static string ToCanvasString(this AssignmentGradingType assignmentGradingType)
        {
            switch (assignmentGradingType)
            {
                case AssignmentGradingType.PassFail:
                    return "pass_fail";
                case AssignmentGradingType.Percent:
                    return "percent";
                case AssignmentGradingType.LetterGrade:
                    return "letter_grade";
                case AssignmentGradingType.GpaScale:
                    return "gpa_scale";
                case AssignmentGradingType.Points:
                    return "points";
                default:
                    throw new InvalidOperationException($"Unable to conver the assignment grading type {assignmentGradingType} to it's Canvas equivalent string.");
            }
        }
    }
}