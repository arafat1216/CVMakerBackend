using Common.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using HTMLTemplateGenerator;

namespace PDFGenerator
{
    public class PDFGeneratorService : IPDFGeneratorService
    {
        private readonly IHTMLTemplateGeneratorService templateGeneratorService;
        private readonly IConverter converter;

        public PDFGeneratorService(IHTMLTemplateGeneratorService templateGeneratorService, IConverter converter)
        {
            this.templateGeneratorService = templateGeneratorService;
            this.converter = converter;
        }
        public async Task<byte[]> GeneratePDF(CVDto cvDto)
        {
            var html = await templateGeneratorService.GenerateHTMLTemplateAsync(cvDto);

            var globalSettings = GetGlobalSettings();

            var objectSettings = GetObjectSettings(html);

            var pdf = GetPdfDocument(globalSettings, objectSettings);

            return converter.Convert(pdf);
        }

        private HtmlToPdfDocument GetPdfDocument(GlobalSettings globalSettings, ObjectSettings objectSettings)
        {
            return new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
        }

        private ObjectSettings GetObjectSettings(string html)
        {
            return new ObjectSettings()
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = new WebSettings() { DefaultEncoding = "utf-8" },
                HeaderSettings = GetHeaderSettings(),
                FooterSettings = GetFooterSettings(),
            };
        }

        private FooterSettings GetFooterSettings()
        {
            return new FooterSettings()
            {
                FontName = "Arial",
                FontSize = 9
            };
        }

        private HeaderSettings GetHeaderSettings()
        {
            return new HeaderSettings()
            {
                FontName = "Arial",
                FontSize = 9
            };
        }

        private GlobalSettings GetGlobalSettings()
        {
            return new GlobalSettings()
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() { Top = 10, Bottom = 10 }
            };
        }
    }
}
