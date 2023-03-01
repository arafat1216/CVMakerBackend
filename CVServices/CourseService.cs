using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository repository;
        private readonly IMapper mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<CourseDto> AddCourse(AddCourseDto addCourseRequest)
        {
            var courseToAdd = mapper.Map<Course>(addCourseRequest);

            var response = await repository.AddCourseAsync(courseToAdd);

            return mapper.Map<CourseDto>(response);
        }

        public async Task DeleteCourse(int courseId)
        {
            var courseToDelete = await repository.GetCourseByIdAsync(courseId);

            if (courseToDelete == null)
                throw new Exceptions.CourseNotFoundException($"Course With Id {courseId} Not Found");

            await repository.DeleteCourseAsync(courseToDelete);
        }

        public async Task<List<CourseDto>> GetAllCourses(string userId)
        {
            var response = await repository.GetAllCoursesAsync(userId);

            return mapper.Map<List<CourseDto>>(response);
        }

        public async Task<CourseDto> GetCourseById(int courseId)
        {
            var course = await repository.GetCourseByIdAsync(courseId);

            if (course == null)
                throw new Exceptions.CourseNotFoundException($"Course With Id {courseId} Not Found");

            return mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> UpdateCourse(CourseDto updateCourseRequest)
        {
            var courseExists = await repository.CourseExistsAsync(updateCourseRequest.Id);

            if (!courseExists)
                throw new Exceptions.CourseNotFoundException($"Course With Id {updateCourseRequest.Id} Not Found");

            var courseToUpdate = mapper.Map<Course>(updateCourseRequest);

            var response = await repository.UpdateCourseAsync(courseToUpdate);

            return mapper.Map<CourseDto>(response);
        }
    }
}
