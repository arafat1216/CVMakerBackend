using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class SkillService : ISkillService
    {
        private readonly HttpClient client;

        public SkillService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<SkillDto> AddSkill(AddSkillDto addskillRequest)
        {
            var response = await client.PostAsJsonAsync("/api/Skills", addskillRequest);

            return await response.Content.ReadAsAsync<SkillDto>();
        }

        public async Task DeleteSkill(int skillId)
        {
            try
            {
                var response = await client.DeleteAsync($"/api/Skills/{skillId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }
 
            }
            catch (Exception ex)
            {

                throw new Exceptions.SkillException($"Skill Delete Failed! {ex.Message}");
            }
        }

        public async Task<List<SkillDto>> GetAllSkills(string userId)
        {
            var response = await client.GetAsync($"/api/Skills?userId={userId}");

            return await response.Content.ReadAsAsync<List<SkillDto>>();
        }

        public async Task<SkillDto> GetSkill(int skillId)
        {
            try
            {
                var response = await client.GetAsync($"/api/Skills/{skillId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<SkillDto>();

            }
            catch (Exception ex)
            {

                throw new Exceptions.SkillException($"{ex.Message}");
            }
        }

        public async Task<SkillDto> UpdateSkill(SkillDto updateSkillRequest)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"/api/Skills/{updateSkillRequest.Id}", updateSkillRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<SkillDto>();

            }
            catch (Exception ex)
            {

                throw new Exceptions.SkillException($"Skill Update Failed! {ex.Message}");
            }
        }
    }
}
