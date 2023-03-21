using Common.Models;

namespace HTMLTemplateGenerator
{
    public class HTMLTemplateGeneratorService : IHTMLTemplateGeneratorService
    {
        public async Task<string> GenerateHTMLTemplateAsync(CVDto cvDto)
        {
            var html = await Razor.Templating.Core.RazorTemplateEngine.RenderAsync("~/Templates/PdfTemplate.cshtml", cvDto);

            return html;
        }
    }
}
