using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository repository;
        private readonly IMapper mapper;

        public WorkExperienceService(IWorkExperienceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<WorkExperienceDto> AddWorkExperience(AddWorkExperienceDto addWorkExperienceRequest)
        {
            var workExperienceToAdd = mapper.Map<WorkExperience>(addWorkExperienceRequest);

            var response = await repository.AddWorkExperienceAsync(workExperienceToAdd);

            return mapper.Map<WorkExperienceDto>(response);
        }

        public async Task DeleteWorkExperience(int workExperieneId)
        {
            var workExperienceToDelete = await repository.GetWorkExperienceByIdAsync(workExperieneId);

            if (workExperienceToDelete == null)
                throw new Exceptions.WorkExperienceNotFoundException($"Work Experinece With Id {workExperieneId} Not Found");

            await repository.DeleteWorkExperienceAsync(workExperienceToDelete);
        }

        public async Task<List<WorkExperienceDto>> GetAllWorkExperiences(string userId)
        {
            var response = await repository.GetAllWorkExperiencesAsync(userId);

            return mapper.Map<List<WorkExperienceDto>>(response);
        }

        public async Task<WorkExperienceDto> GetWorkExperienceById(int workExperieneId)
        {
            var workExperience = await repository.GetWorkExperienceByIdAsync(workExperieneId);

            if (workExperience == null)
                throw new Exceptions.WorkExperienceNotFoundException($"Work Experience With Id {workExperieneId} Not Found");

            return mapper.Map<WorkExperienceDto>(workExperience);
        }

        public async Task<WorkExperienceDto> UpdateWorkExperience(WorkExperienceDto updateWorkExperienceRequest)
        {
            var workExperienceExists = await repository.WorkExperienceExistsAsync(updateWorkExperienceRequest.Id);

            if (!workExperienceExists)
                throw new Exceptions.WorkExperienceNotFoundException($"Work Experience With Id {updateWorkExperienceRequest.Id} Not Found");

            var workExperienceToUpdate = mapper.Map<WorkExperience>(updateWorkExperienceRequest);

            var response = await repository.UpdateWorkExperienceAsync(workExperienceToUpdate);

            return mapper.Map<WorkExperienceDto>(response);
        }
    }
}
