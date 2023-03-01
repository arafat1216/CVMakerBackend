using CVMakerApiGateway.Contracts.Services;
using CVMakerApiGateway.Models;

namespace CVMakerApiGateway.Services
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient client;

        public CourseService(HttpClient client)
        {
            this.client = client;
        }
        public async Task<CourseDto> AddCourse(AddCourseDto addCourseRequest)
        {
            var response = await client.PostAsJsonAsync("/api/Courses", addCourseRequest);

            return await response.Content.ReadAsAsync<CourseDto>();
        }

        public async Task DeleteCourse(int courseId)
        {
            try
            {
                var response = await client.DeleteAsync($"/api/Courses/{courseId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }
            }
            catch (Exception ex)
            {

                throw new Exceptions.CourseException($"Course Delete Failed! {ex.Message}");
            }
        }

        public async Task<List<CourseDto>> GetAllCourses(string userId)
        {
            var response = await client.GetAsync($"/api/Courses?userid={userId}");

            return await response.Content.ReadAsAsync<List<CourseDto>>();
        }

        public async Task<CourseDto> GetCourse(int courseId)
        {
            try
            {
                var response = await client.GetAsync($"/api/Courses/{courseId}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<CourseDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.CourseException($"{ex.Message}");
            }
        }

        public async Task<CourseDto> UpdateCourse(CourseDto updateCourseRequest)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"/api/Courses/{updateCourseRequest.Id}", updateCourseRequest);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDescription = await response.Content.ReadAsAsync<ErrorDto>();

                    var exception = new BadHttpRequestException(errorDescription.Message, (int)response.StatusCode);

                    throw exception;
                }

                return await response.Content.ReadAsAsync<CourseDto>();
            }
            catch (Exception ex)
            {

                throw new Exceptions.CourseException($"Course Update Failed! {ex.Message}");
            }
        }
    }
}
