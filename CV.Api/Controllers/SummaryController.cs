using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryService summaryService;

        public SummaryController(ISummaryService summaryService)
        {
            this.summaryService = summaryService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSummary([FromRoute] string userId)
        {
            var response = await summaryService.GetSummary(userId);
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSummary([FromBody] SummaryDto summaryUpdateRequest)
        {
            var response = await summaryService.UpdateSummary(summaryUpdateRequest);

            return Ok(response);
        }
    }
}
