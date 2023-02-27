using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository repository;
        private readonly IMapper mapper;

        public SkillService(ISkillRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<SkillDto> AddSkill(AddSkillDto addSkillRequest)
        {
            var skillToAdd = mapper.Map<Skill>(addSkillRequest);

            var response = await repository.AddSkillAsync(skillToAdd);

            return mapper.Map<SkillDto>(response);
        }

        public async Task DeleteSkill(int skillId)
        {
            var skillToDelete = await repository.GetSkillByIdAsync(skillId);

            if (skillToDelete == null)
                throw new Exceptions.SkillNotFoundException($"Skill With Id {skillId} Not Found");

            await repository.DeleteSkillAsync(skillToDelete);
        }

        public async Task<List<SkillDto>> GetAllSkills(string userId)
        {
            var response = await repository.GetAllSkillsAsync(userId);

            return mapper.Map<List<SkillDto>>(response);
        }

        public async Task<SkillDto> GetSkillById(int skillId)
        {
            var skill = await repository.GetSkillByIdAsync(skillId);

            if (skill == null)
                throw new Exceptions.SkillNotFoundException($"Skill With Id {skillId} Not Found");

            return mapper.Map<SkillDto>(skill);
        }

        public async Task<SkillDto> UpdateSkill(SkillDto updateSkillRequest)
        {
            var skillExists = await repository.SkillExistsAsync(updateSkillRequest.Id);

            if(!skillExists)
                throw new Exceptions.SkillNotFoundException($"Skill With Id {updateSkillRequest.Id} Not Found");

            var skillToUpdate = mapper.Map<Skill>(updateSkillRequest);
            
            var response = await repository.UpdateSkillAsync(skillToUpdate);

            return mapper.Map<SkillDto>(response);
        }
    }
}
