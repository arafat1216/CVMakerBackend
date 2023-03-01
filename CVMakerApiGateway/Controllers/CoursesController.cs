using AutoMapper;
using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVMakerApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await courseService.GetAllCourses(userId);

            return Ok(response);
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourse([FromRoute] int courseId)
        {
            var response = await courseService.GetCourse(courseId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseViewModel addCourseRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var courseToAdd = mapper.Map<AddCourseDto>(addCourseRequest);

            courseToAdd.UserId = userId;

            var response = await courseService.AddCourse(courseToAdd);

            return Ok(response);
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int courseId, [FromBody] CourseViewModel updateCourseRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var courseToUpdate = mapper.Map<CourseDto>(updateCourseRequest);

            courseToUpdate.UserId = userId;

            courseToUpdate.Id = courseId;

            var response = await courseService.UpdateCourse(courseToUpdate);

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
