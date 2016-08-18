using System.Threading.Tasks;
using System.Web.Http;
using Canvas.LMS.Demo.Core;
using Canvas.LMS.Demo.Core.Coordinators;
using Canvas.LMS.Demo.Core.Domain;

namespace Canvas.LMS.Demo.WebApi.Controllers
{
    public class EnrollmentController : ApiController
    {
        private readonly EnrollmentCoordinator _enrollmentCoordinator;

        public EnrollmentController()
        {
            _enrollmentCoordinator = new EnrollmentCoordinator();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string userId, string courseId)
        {
            //EnrollmentDto enrollment = await _enrollmentCoordinator.EnrollUserToCourse(userId, courseId);
            //return Ok(enrollment);

            return Ok();
        }
    }
}