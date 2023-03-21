using AutoMapper;
using Common.Models;
using CVMakerApiGateway.Contracts.Services;
using HTMLTemplateGenerator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDFGenerator;

namespace CVMakerApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CVController : ControllerBase
    {
        private readonly ICVService cVService;
        private readonly IMapper mapper;
        private readonly IHTMLTemplateGeneratorService templateGeneratorService;
        private readonly IPDFGeneratorService pdfGeneratorService;

        public CVController(ICVService cVService, IMapper mapper, IHTMLTemplateGeneratorService templateGeneratorService, IPDFGeneratorService pdfGeneratorService)
        {
            this.cVService = cVService;
            this.mapper = mapper;
            this.templateGeneratorService = templateGeneratorService;
            this.pdfGeneratorService = pdfGeneratorService;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCV()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var response = await cVService.GetCV(userId);

            CVDto cvDto = mapper.Map<CVDto>(response);

            var file = await pdfGeneratorService.GeneratePDF(cvDto);

            return File(file, "application/octet-stream", "Resume.pdf");

        }
    }
}
