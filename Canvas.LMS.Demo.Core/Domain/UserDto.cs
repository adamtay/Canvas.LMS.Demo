using System;
using System.Collections.Generic;

namespace Canvas.LMS.Demo.Core.Domain
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SortableName { get; set; }

        public string ShortName { get; set; }

        public string SISUserId { get; set; }

        public string SisImportId { get; set; }

        public string IntegrationId { get; set; }

        public string LoginId { get; set; }

        public string AvatarUrl { get; set; }

        public List<CourseEnrollmentDto> Enrollments { get; set; }

        public string Email { get; set; }

        public string Locale { get; set; }

        public DateTime LastLogin { get; set; }

        public string TimeZone { get; set; }

        public string Bio { get; set; }
    }
}