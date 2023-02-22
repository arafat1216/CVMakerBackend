using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : ControllerBase
    {
        private readonly ISocialLinksService socialLinksService;

        public SocialLinksController(ISocialLinksService socialLinksService)
        {
            this.socialLinksService = socialLinksService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetSocialLinks([FromRoute] string userId)
        {
            var response = await socialLinksService.GetSocialLinks(userId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialLinks(SocialLinkDto socialLinksUpadateRequest)
        {
            var response = await socialLinksService.UpdateSocialLinks(socialLinksUpadateRequest);

            return Ok(response);
        }
    }
}
