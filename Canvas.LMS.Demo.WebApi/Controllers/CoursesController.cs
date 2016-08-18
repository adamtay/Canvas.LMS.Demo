using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Canvas.LMS.Demo.Core;
using Canvas.LMS.Demo.Core.Coordinators;
using Canvas.LMS.Demo.Core.Domain;

namespace Canvas.LMS.Demo.WebApi.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly CoursesCoordinator _coursesCoordinator;

        public CoursesController()
        {
            _coursesCoordinator = new CoursesCoordinator();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            //IEnumerable<CourseDto> courses = await _coursesCoordinator.GetCourses();
            //return Ok(courses);

            return Ok();
        }
    }
}