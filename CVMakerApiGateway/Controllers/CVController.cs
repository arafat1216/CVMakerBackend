using AutoMapper;
using Common.Models;
using CVMakerApiGateway.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVMakerApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ICVService cVService;
        private readonly IMapper mapper;

        public CVController(ICVService cVService, IMapper mapper)
        {
            this.cVService = cVService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCV()
        {
            var userId = "00u8cxenvnrME3LPE5d7";

            var response = await cVService.GetCV(userId);

            CVDto cvDto = mapper.Map<CVDto>(response);

            return Ok(cvDto);


        }
    }
}
