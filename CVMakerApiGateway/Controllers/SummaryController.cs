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
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService summaryService;
        private readonly IMapper mapper;

        public SummaryController(ISummaryService summaryService, IMapper mapper)
        {
            this.summaryService = summaryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSummary()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await summaryService.GetSummary(userId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSummary([FromBody] SummaryViewModel updateSummaryRequest)
        {
            var summary = mapper.Map<SummaryDto>(updateSummaryRequest);

            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            summary.UserId = userId;

            var response = await summaryService.UpdateSummary(summary);

            return Ok(response);
        }
    }
}
