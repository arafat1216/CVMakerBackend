using AutoMapper;
using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;
using CVMakerApiGateway.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVMakerApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperiencesController : ControllerBase
    {
        private readonly IWorkExperienceService workExperienceService;
        private readonly IMapper mapper;

        public WorkExperiencesController(IWorkExperienceService workExperienceService, IMapper mapper)
        {
            this.workExperienceService = workExperienceService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkExperiences()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await workExperienceService.GetAllWorkExperiences(userId);

            return Ok(response);
        }

        [HttpGet("{workExperienceId}")]
        public async Task<IActionResult> GetWorkExperience([FromRoute] int workExperienceId)
        {
            var response = await workExperienceService.GetWorkExperience(workExperienceId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkExperience([FromBody] WorkExperienceViewModel addWorkExperienceRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var workExperienceToAdd = mapper.Map<AddWorkExperienceDto>(addWorkExperienceRequest);

            workExperienceToAdd.UserId = userId;

            var response = await workExperienceService.AddWorkExperience(workExperienceToAdd);

            return Ok(response);
        }

        [HttpPut("{workExperienceId}")]
        public async Task<IActionResult> UpdateWorkExperience([FromRoute] int workExperienceId, [FromBody] WorkExperienceViewModel updateWorkExperienceRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var workExperienceToUpdate = mapper.Map<WorkExperienceDto>(updateWorkExperienceRequest);

            workExperienceToUpdate.Id = workExperienceId;

            workExperienceToUpdate.UserId = userId;

            var response = await workExperienceService.UpdateWorkExperience(workExperienceToUpdate);

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
