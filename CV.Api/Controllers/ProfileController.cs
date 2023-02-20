using CVServices.Contracts.Services;
using CVServices.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile([FromRoute] string userId)
        {
            var profile = await profileService.GetProfile(userId);

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(ProfileDto profileUpadateRequest)
        {
            var response = await profileService.UpdateProfile(profileUpadateRequest);

            return Ok(response);
        }
    }
}
