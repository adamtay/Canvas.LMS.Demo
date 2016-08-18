using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Canvas.LMS.Demo.Core.Domain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssignmentExtensionType
    {
        Docx,
        Pdf,
        Ppt
    }
}