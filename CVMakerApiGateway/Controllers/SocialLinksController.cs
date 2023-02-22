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
    public class SocialLinksController : ControllerBase
    {
        private readonly ISocialLinksService socialLinksService;
        private readonly IMapper mapper;

        public SocialLinksController(ISocialLinksService socialLinksService, IMapper mapper)
        {
            this.socialLinksService = socialLinksService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSocialLinks()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await socialLinksService.GetSocialLinks(userId);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialLinks(SocialLinkViewModel updateSocialLinksRequest)
        {
            var socialLinks = mapper.Map<SocialLinkDto>(updateSocialLinksRequest);

            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            socialLinks.UserId = userId;

            var response = await socialLinksService.UpdateSocialLinks(socialLinks);

            return Ok(response);
        }
    }
}
