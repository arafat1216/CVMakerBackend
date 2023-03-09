using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface IDegreeRepository
    {
        Task<Degree> AddDegreeAsync(Degree degree);
        Task DeleteDegreeAsync(Degree degree);
        Task<bool> DegreeExistsAsync(int degreeId);
        Task<List<Degree>> GetAllDegreesAsync(string userId);
        Task<Degree?> GetDegreeByIdAsync(int degreeId);
        Task SaveChanges();
        Task<Degree> UpdateDegreeAsync(Degree degree);
    }
}
