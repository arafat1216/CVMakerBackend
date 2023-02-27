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
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService skillService;
        private readonly IMapper mapper;

        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await skillService.GetAllSkills(userId);

            return Ok(response);
        }

        [HttpGet("{skillId}")]
        public async Task<IActionResult> GetSkill([FromRoute] int skillId)
        {
            var response = await skillService.GetSkill(skillId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] SkillViewModel addSkillRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var skillToAdd = mapper.Map<AddSkillDto>(addSkillRequest);

            skillToAdd.UserId = userId;

            var response = await skillService.AddSkill(skillToAdd);

            return Ok(response);
        }

        [HttpPut("{skillId}")]
        public async Task<IActionResult> UpdateSkill([FromRoute] int skillId, [FromBody] SkillViewModel updateSkillRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var skillToUpdate = mapper.Map<SkillDto>(updateSkillRequest);

            skillToUpdate.Id = skillId;

            skillToUpdate.UserId = userId;

            var response = await skillService.UpdateSkill(skillToUpdate);

            return Ok(response);
        }

        [HttpDelete("{skillId}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] int skillId)
        {
            await skillService.DeleteSkill(skillId);

            return NoContent();
        }
    }
}
