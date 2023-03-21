using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class CVService : ICVService
    {
        private readonly HttpClient client;

        public CVService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<CVDto> GetCV(string userId)
        {
            var cvDto = new CVDto();
            
            cvDto.Profile = await GetProfile(userId);

            cvDto.SocialLinks = await GetSocialLinks(userId);

            cvDto.Summary = await GetSummary(userId);

            cvDto.WorkExperiences = await GetWorkExperiences(userId);

            cvDto.WorkExperiences = processTasks(cvDto.WorkExperiences);

            cvDto.WorkExperiences = processDates(cvDto.WorkExperiences);

            cvDto.Skills = await GetSkills(userId);

            cvDto.Degrees = await GetDegrees(userId);

            cvDto.Projects = await GetProjects(userId);

            cvDto.Courses = await GetCourses(userId);

            return cvDto;
        }

        private async Task<SocialLinkDto> GetSocialLinks(string userId)
        {
            var response = await client.GetAsync($"/api/SocialLinks/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return new SocialLinkDto();
            }

            return await response.Content.ReadAsAsync<SocialLinkDto>();
        }

        private async Task<List<CourseDto>> GetCourses(string userId)
        {
            var response = await client.GetAsync($"/api/Courses?userid={userId}");

            return await response.Content.ReadAsAsync<List<CourseDto>>();
        }

        private async Task<List<ProjectDto>> GetProjects(string userId)
        {
            var response = await client.GetAsync($"/api/Projects?userId={userId}");

            return await response.Content.ReadAsAsync<List<ProjectDto>>();
        }

        private async Task<List<DegreeDto>> GetDegrees(string userId)
        {
            var response = await client.GetAsync($"/api/Degrees?userid={userId}");

            return await response.Content.ReadAsAsync<List<DegreeDto>>();
        }

        private async Task<List<SkillDto>> GetSkills(string userId)
        {
            var response = await client.GetAsync($"/api/Skills?userId={userId}");

            return await response.Content.ReadAsAsync<List<SkillDto>>();
        }

        private List<WorkExperienceWithTasksDto> processDates(List<WorkExperienceWithTasksDto> workExperiences)
        {
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            foreach (var workExperience in workExperiences)
            {
                var startDate = Convert.ToDateTime(workExperience.StartDate);

                var startMonth = startDate.Month;

                var startYear = startDate.Year;

                workExperience.StartDate = $"{months[startMonth-1]} {startYear}";

                if (workExperience.EndDate != "Present")
                {
                    var endDate = Convert.ToDateTime(workExperience.EndDate);

                    var endMonth = endDate.Month;

                    var endYear = endDate.Year;

                    workExperience.EndDate = $"{months[endMonth-1]} {endYear}";
                }
            }

            return workExperiences;
        }

        private List<WorkExperienceWithTasksDto> processTasks(List<WorkExperienceWithTasksDto> workExperiences)
        {
            foreach (var workExperience in workExperiences)
            {
                string[] tasks = workExperience.Description.Split("#");

                workExperience.Tasks = new List<string>(tasks);
            }
            
            return workExperiences;
        }

        private async Task<List<WorkExperienceWithTasksDto>> GetWorkExperiences(string userId)
        {
            var response = await client.GetAsync($"/api/WorkExperiences?userid={userId}");

            return await response.Content.ReadAsAsync<List<WorkExperienceWithTasksDto>>();
        }

        private async Task<SummaryDto> GetSummary(string userId)
        {
            var response = await client.GetAsync($"/api/Summary/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return new SummaryDto();
            }

            return await response.Content.ReadAsAsync<SummaryDto>();
        }

        private async Task<ProfileDto> GetProfile(string userId)
        {
            var response = await client.GetAsync($"/api/Profile/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ProfileDto();
            }

            return await response.Content.ReadAsAsync<ProfileDto>();   
        }
    }
}
