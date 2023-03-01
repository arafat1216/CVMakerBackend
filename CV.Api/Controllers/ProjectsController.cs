using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects([FromQuery] string userId)
        {
            var response = await projectService.GetAllProjects(userId);

            return Ok(response);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProject([FromRoute] int projectId)
        {
            var response = await projectService.GetProjectById(projectId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] AddProjectDto addProjectRequest)
        {
            var response = await projectService.AddProject(addProjectRequest);

            return Ok(response);
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject([FromRoute] int projectId, [FromBody] ProjectDto updateProjectRequet)
        {
            var response = await projectService.UpdateProject(updateProjectRequet);

            return Ok(response);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int projectId)
        {
            await projectService.DeleteProject(projectId);

            return NoContent();
        }
    }
}
