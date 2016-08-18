using System;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Tests.Builders
{
    public class CreateCourseRequestDtoBuilder
    {
        private readonly string _name;
        private readonly string _courseCode;
        private readonly DateTime _startAt;
        private readonly DateTime? _endAt;
        private readonly bool _isPublic;
        private readonly bool _isPublicToAuthUsers;
        private readonly bool _publicSyllabus;
        private readonly string _publicDescription;
        private readonly bool _allowWikiComments;
        private readonly bool _allowStudentForumAttachments;
        private readonly bool _openEnrollment;
        private readonly bool _selfEnrollment;
        private readonly bool _restrictEnrollmentsToCourseDates;
        private readonly bool _offer;

        public CreateCourseRequestDtoBuilder()
        {
            _name = "Principles to Programming";
            _courseCode = "COMPSCI 101";
            _startAt = DateTime.UtcNow;
            _endAt = DateTime.UtcNow.AddMonths(3);
            _isPublic = true;
            _isPublicToAuthUsers = true;
            _publicSyllabus = true;
            _publicDescription = "Learn to write code";
            _allowWikiComments = true;
            _allowStudentForumAttachments = true;
            _openEnrollment = true;
            _selfEnrollment = true;
            _restrictEnrollmentsToCourseDates = true;
            _offer = true;
        }

        public CreateCourseRequestDto Build()
        {
            return new CreateCourseRequestDto
            {
                Name = _name,
                CourseCode = _courseCode,
                StartAt = _startAt,
                EndAt = _endAt,
                IsPublic = _isPublic,
                IsPublicToAuthUsers = _isPublicToAuthUsers,
                PublicSyllabus = _publicSyllabus,
                PublicDescription = _publicDescription,
                AllowWikiComments = _allowWikiComments,
                AllowStudentForumAttachments = _allowStudentForumAttachments,
                OpenEnrollment = _openEnrollment,
                SelfEnrollment = _selfEnrollment,
                RestrictEnrollmentsToCourseDates = _restrictEnrollmentsToCourseDates,
                Offer = _offer
            };
        }
    }
}