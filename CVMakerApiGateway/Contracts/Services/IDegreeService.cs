using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Contracts.Services
{
    public interface IDegreeService
    {
        Task<List<DegreeDto>> GetAllDegrees(string userId);
        Task<DegreeDto> GetDegreeById(int degreeId);
        Task<DegreeDto> AddDegree(AddDegreeDto addDegreeRequest);
        Task<DegreeDto> UpdateDegree(DegreeDto updateDegreeRequest);
        Task DeleteDegree(int degreeId);
    }
}
