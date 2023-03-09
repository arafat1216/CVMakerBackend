using CVServices.ServiceModels;

namespace CVServices.Contracts.Services
{
    public interface IDegreeService
    {
        Task<DegreeDto> AddDegree(AddDegreeDto addDegreeRequest);
        Task DeleteDegree(int degreeId);
        Task<List<DegreeDto>> GetAllDegrees(string userId);
        Task<DegreeDto> GetDegreeById(int degreeId);
        Task<DegreeDto> UpdateDegree(DegreeDto updateDegreeRequest);
    }
}
