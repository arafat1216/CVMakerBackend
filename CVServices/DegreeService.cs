using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class DegreeService : IDegreeService
    {
        private readonly IDegreeRepository repository;
        private readonly IMapper mapper;

        public DegreeService(IDegreeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<DegreeDto> AddDegree(AddDegreeDto addDegreeRequest)
        {
            var degreeToAdd = mapper.Map<Degree>(addDegreeRequest);

            var response = await repository.AddDegreeAsync(degreeToAdd);

            return mapper.Map<DegreeDto>(response);
        }

        public async Task DeleteDegree(int degreeId)
        {
            var degreeToDelete = await repository.GetDegreeByIdAsync(degreeId);

            if (degreeToDelete == null)
                throw new Exceptions.DegreeNotFoundException($"Degree With Id {degreeId} Not Found");

            await repository.DeleteDegreeAsync(degreeToDelete);
        }

        public async Task<List<DegreeDto>> GetAllDegrees(string userId)
        {
            var response = await repository.GetAllDegreesAsync(userId);

            return mapper.Map<List<DegreeDto>>(response);
        }

        public async Task<DegreeDto> GetDegreeById(int degreeId)
        {
            var degree = await repository.GetDegreeByIdAsync(degreeId);

            if (degree == null)
                throw new Exceptions.DegreeNotFoundException($"Degree With Id {degreeId} Not Found");

            return mapper.Map<DegreeDto>(degree);
        }

        public async Task<DegreeDto> UpdateDegree(DegreeDto updateDegreeRequest)
        {
            var degreeExists = await repository.DegreeExistsAsync(updateDegreeRequest.Id);

            if (!degreeExists)
                throw new Exceptions.DegreeNotFoundException($"Degree With Id {updateDegreeRequest.Id} Not Found");

            var degreeToUpdate = mapper.Map<Degree>(updateDegreeRequest);

            var response = await repository.UpdateDegreeAsync(degreeToUpdate);

            return mapper.Map<DegreeDto>(response); 
        }
    }
}
