using Common.Models;

namespace HTMLTemplateGenerator
{
    public interface IHTMLTemplateGeneratorService
    {
        Task<string> GenerateHTMLTemplateAsync(CVDto cvDto);
    }
}
