using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface ISummaryRepository
    {
        Task<Summary> CreateSummaryAsync(Summary summary);
        Task<Summary?> GetSummaryAsync(string userId);
        Task<bool> SummaryExists(string userId);
        Task<Summary> UpdateSummaryAsync(Summary summary);
        Task SaveChanges();
    }
}
