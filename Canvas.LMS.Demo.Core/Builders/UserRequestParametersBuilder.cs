using System;
using System.Collections.Generic;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.Core.Builders
{
    /// <summary>
    /// Responsible for building the <see cref="CreateUserRequestDto"/> request parameters.
    /// </summary>
    public class UserRequestParametersBuilder
    {
        private readonly CreateUserRequestDto _createUserRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRequestParametersBuilder"/> class.
        /// </summary>
        public UserRequestParametersBuilder(CreateUserRequestDto createUserRequest)
        {
            if (createUserRequest == null) throw new ArgumentNullException(nameof(createUserRequest));

            _createUserRequest = createUserRequest;
        }

        /// <summary>
        /// Builds the request parameters.
        /// </summary>
        public Dictionary<string, string> Build()
        {
            return new Dictionary<string, string>
            {
                {"user[name]", _createUserRequest.Name},
                {"user[short_name]", _createUserRequest.ShortName},
                {"user[sortable_name]", _createUserRequest.SortableName},
                {"user[time_zone]", _createUserRequest.TimeZone},
                {"user[locale]", _createUserRequest.Locale},
                //{"user[birthdate]", _createUserRequest.BirthDate.ToString(CultureInfo.CurrentCulture)},
                {"user[terms_of_use]", _createUserRequest.TermsOfUse.ToString()},
                {"user[skip_registration]", _createUserRequest.SkipRegistration.ToString()},
                {"pseudonym[unique_id]", _createUserRequest.UniqueId},
                {"pseudonym[password]", _createUserRequest.Password}
            };
        }
    }
}