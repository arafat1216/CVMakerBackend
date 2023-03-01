using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses([FromQuery] string userid)
        {
            var response = await courseService.GetAllCourses(userid);

            return Ok(response);
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse([FromRoute] int courseId)
        {
            var response = await courseService.GetCourseById(courseId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseDto addCourseRequest)
        {
            var response = await courseService.AddCourse(addCourseRequest);

            return Ok(response);
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int courseId, [FromBody] CourseDto updateCourseRequest)
        {
            var response = await courseService.UpdateCourse(updateCourseRequest);

            return Ok(response);
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int courseId)
        {
            await courseService.DeleteCourse(courseId);

            return NoContent();
        }

    }
}
