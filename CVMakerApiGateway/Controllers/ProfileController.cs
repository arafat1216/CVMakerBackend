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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;
        private readonly IMapper mapper;

        public ProfileController(IProfileService profileService, IMapper mapper)
        {
            this.profileService = profileService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userId = (User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value).ToString();

            var response = await profileService.GetProfile(userId);

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileViewModel updateProfileRequest)
        {
            var profile = mapper.Map<ProfileDto>(updateProfileRequest);

            var userId = (User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value).ToString();

            

            profile.UserId = userId;

            var response = await profileService.UpdateProfile(profile);

            return Ok(response);
        }
    }
}
