using Common.Models;

namespace PDFGenerator
{
    public interface IPDFGeneratorService
    {
        Task<byte[]> GeneratePDF(CVDto cvDto);
    }
}
