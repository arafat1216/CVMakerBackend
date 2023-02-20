using CVMakerApiGateway.Models;
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
        [HttpGet]
        public IActionResult GetProfileDescription()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            ProfileResponse profileResponse = new ProfileResponse()
            {
                FullName = userId
            };
            return Ok(profileResponse);
        }
    }
}
