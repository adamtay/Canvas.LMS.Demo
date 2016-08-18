using System;

namespace Canvas.LMS.Demo.Core.Requests
{
    public class CreateUserRequestDto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string SortableName { get; set; }

        public string TimeZone { get; set; }

        public string Locale { get; set; }

        public DateTime BirthDate { get; set; }

        public bool TermsOfUse { get; set; } = true;

        public bool SkipRegistration { get; set; } = true;

        public string UniqueId { get; set; }

        public string Password { get; set; }
    }
}