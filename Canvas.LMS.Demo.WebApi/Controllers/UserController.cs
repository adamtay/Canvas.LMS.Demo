using System;
using System.Web.Http;
using Canvas.LMS.Demo.Core;
using Canvas.LMS.Demo.Core.Coordinators;
using Canvas.LMS.Demo.Core.Requests;

namespace Canvas.LMS.Demo.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly UsersCoordinator _userCoordinator;

        public UserController()
        {
            _userCoordinator = new UsersCoordinator();
        }

        [HttpPost]
        [Route("api/User/CreateUser")]
        public IHttpActionResult CreateUser(CreateUserRequestDto userRequestDto)
        {
            //if (userRequestDto == null) throw new ArgumentNullException(nameof(userRequestDto));
            //return Ok(_userCoordinator.CreateUser(userRequestDto));

            return Ok();
        }
    }
}
