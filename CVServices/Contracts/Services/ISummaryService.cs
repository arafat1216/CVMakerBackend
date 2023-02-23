using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface ISummaryService
    {
        Task<SummaryDto> GetSummary(string userId);
        Task<SummaryDto> UpdateSummary(SummaryDto summary);
    }
}
