using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperiencesController : ControllerBase
    {
        private readonly IWorkExperienceService workExperienceService;

        public WorkExperiencesController(IWorkExperienceService workExperienceService)
        {
            this.workExperienceService = workExperienceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkExperiences([FromQuery] string userId)
        {
            var response = await workExperienceService.GetAllWorkExperiences(userId);

            return Ok(response);
        }

        [HttpGet("{workExperienceId}")]
        public async Task<IActionResult> GetWorkExperienceById([FromRoute] int workExperienceId)
        {
            var response = await workExperienceService.GetWorkExperienceById(workExperienceId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkExperience([FromBody] AddWorkExperienceDto addWorkExperienceRequest)
        {
            var response = await workExperienceService.AddWorkExperience(addWorkExperienceRequest);

            return Ok(response);
        }

        [HttpPut("{workExperienceId}")]
        public async Task<IActionResult> UpdateWorkExperience([FromRoute] int workExperienceId, [FromBody] WorkExperienceDto updateWorkExperienceRequest)
        {
            var response = await workExperienceService.UpdateWorkExperience(updateWorkExperienceRequest);

            return Ok(response);
        }

        [HttpDelete("{workExperienceId}")]
        public async Task<IActionResult> DeleteWorkExperience([FromRoute] int workExperienceId)
        {
            await workExperienceService.DeleteWorkExperience(workExperienceId);

            return NoContent();
        }
    }
}
