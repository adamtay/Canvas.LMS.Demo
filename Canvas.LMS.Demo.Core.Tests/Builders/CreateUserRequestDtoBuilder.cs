﻿using System;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Tests.Builders
{
    public class CreateUserRequestDtoBuilder
    {
        private readonly string _name;
        private readonly string _shortName;
        private readonly string _sortableName;
        private readonly string _timeZone;
        private readonly string _locale;
        private readonly DateTime _birthDate;
        private readonly bool _termsOfUse;
        private readonly bool _skipRegistration;
        private readonly string _uniqueId;
        private readonly string _password;

        public CreateUserRequestDtoBuilder()
        {
            Guid id = Guid.NewGuid();

            _name = $"Test User {id}";
            _shortName = $"Test User {id}";
            _sortableName = $"User {id}, Test";
            _timeZone = "Pacific/Auckland";
            _locale = "en";
            _birthDate = DateTime.UtcNow.AddYears(-20);
            _termsOfUse = true;
            _skipRegistration = true;
            _uniqueId = $"user{id}@example.com";
            _password = $"password{id}";
        }

        public CreateUserRequestDto Build()
        {
            return new CreateUserRequestDto
            {
                Name = _name,
                ShortName = _shortName,
                SortableName = _sortableName,
                TimeZone = _timeZone,
                Locale = _locale,
                BirthDate = _birthDate,
                TermsOfUse = _termsOfUse,
                SkipRegistration = _skipRegistration,
                UniqueId = _uniqueId,
                Password = _password
            };
        }
    }
}