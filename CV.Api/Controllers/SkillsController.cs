using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService skillService;

        public SkillsController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills([FromQuery] string userId)
        {
            var response = await skillService.GetAllSkills(userId);

            return Ok(response);
        }

        [HttpGet("{skillId}")]
        public async Task<IActionResult> GetSkill([FromRoute] int skillId)
        {
            var response = await skillService.GetSkillById(skillId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] AddSkillDto addSkillRequest)
        {
            var response = await skillService.AddSkill(addSkillRequest);

            return Ok(response);
        }

        [HttpPut("{skillId}")]
        public async Task<IActionResult> UpdateSkill([FromRoute] int skillId, [FromBody] SkillDto updateSkillRequest)
        {
            var response = await skillService.UpdateSkill(updateSkillRequest);

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
