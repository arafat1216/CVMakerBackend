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
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await projectService.GetAllProjects(userId);

            return Ok(response);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProject([FromRoute] int projectId)
        {
            var response = await projectService.GetProject(projectId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] ProjectViewModel addProjectRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var projectToAdd = mapper.Map<AddProjectDto>(addProjectRequest);

            projectToAdd.UserId = userId;

            var response = await projectService.AddProject(projectToAdd);

            return Ok(response);
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject([FromRoute] int projectId, [FromBody] ProjectViewModel updateProjectRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var projectToUpdate = mapper.Map<ProjectDto>(updateProjectRequest);

            projectToUpdate.UserId = userId;

            projectToUpdate.Id = projectId;

            var response = await projectService.UpdateProject(projectToUpdate);

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
