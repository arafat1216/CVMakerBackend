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
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeService degreeService;
        private readonly IMapper mapper;

        public DegreesController(IDegreeService degreeService, IMapper mapper)
        {
            this.degreeService = degreeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDegrees()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

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
        public async Task<IActionResult> AddDegree([FromBody] DegreeViewModel addDegreeRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var degreeToAdd = mapper.Map<AddDegreeDto>(addDegreeRequest);

            degreeToAdd.UserId = userId;

            var response = await degreeService.AddDegree(degreeToAdd);

            return Ok(response);
        }

        [HttpPut("{degreeId}")]
        public async Task<IActionResult> UpdateDegree([FromRoute] int degreeId, [FromBody]DegreeViewModel updateDegreeRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var degreeToUpdate = mapper.Map<DegreeDto>(updateDegreeRequest);

            degreeToUpdate.UserId = userId;

            degreeToUpdate.Id = degreeId;

            var response = await degreeService.UpdateDegree(degreeToUpdate);

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
