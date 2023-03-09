using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeService degreeService;

        public DegreesController(IDegreeService degreeService)
        {
            this.degreeService = degreeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDegrees([FromQuery] string userId)
        {
            var response = await degreeService.GetAllDegrees(userId);

            return Ok(response);
        }

        [HttpGet("{degreeId}")]
        public async Task<IActionResult> GetDegree([FromRoute] int degreeId)
        {
            var response = await degreeService.GetDegreeById(degreeId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddDegree([FromBody] AddDegreeDto addDegreeRequest)
        {
            var response = await degreeService.AddDegree(addDegreeRequest);

            return Ok(response);
        }

        [HttpPut("{degreeId}")]
        public async Task<IActionResult> UpdateDegree([FromRoute] int degreeId, [FromBody] DegreeDto updateDegreeRequest)
        {
            var response = await degreeService.UpdateDegree(updateDegreeRequest);

            return Ok(response);
        }

        [HttpDelete("{degreeId}")]
        public async Task<IActionResult> DeleteDegree([FromRoute] int degreeId)
        {
            await degreeService.DeleteDegree(degreeId);

            return NoContent();
        }
    }
}
