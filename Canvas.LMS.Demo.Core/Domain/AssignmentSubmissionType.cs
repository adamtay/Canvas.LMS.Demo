using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Canvas.LMS.Demo.Core.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssignmentSubmissionType
    {
        DiscussionTopic,
        OnlineQuiz,
        OnPaper,
        None,
        ExternalTool,
        OnlineTextEntry,
        OnlineUrl,
        OnlineUpload,
        MediaRecording
    }

    public static class AssignmentSubmissionTypeExtensionMethods
    {
        public static string ToCanvasString(this AssignmentSubmissionType assignmentSubmissionType)
        {
            switch (assignmentSubmissionType)
            {
                case AssignmentSubmissionType.DiscussionTopic:
                    return "discussion_topic";
                case AssignmentSubmissionType.OnlineQuiz:
                    return "online_quiz";
                case AssignmentSubmissionType.OnPaper:
                    return "on_paper";
                case AssignmentSubmissionType.None:
                    return "none";
                case AssignmentSubmissionType.ExternalTool:
                    return "external_tool";
                case AssignmentSubmissionType.OnlineTextEntry:
                    return "online_text_entry";
                case AssignmentSubmissionType.OnlineUrl:
                    return "online_url";
                case AssignmentSubmissionType.OnlineUpload:
                    return "online_upload";
                case AssignmentSubmissionType.MediaRecording:
                    return "media_recording";
                default:
                    throw new InvalidOperationException($"Unable to conver the assignment submission type {assignmentSubmissionType} to it's Canvas equivalent string.");
            }
        }
    }
}