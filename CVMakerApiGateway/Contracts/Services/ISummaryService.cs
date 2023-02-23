using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface ISummaryService
    {
        Task<SummaryDto> GetSummary(string userId);

        Task<SummaryDto> UpdateSummary(SummaryDto summary);
    }
}
