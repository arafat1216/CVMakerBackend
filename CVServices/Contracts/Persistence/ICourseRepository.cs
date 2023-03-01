using CVServices.Entities;

namespace CVServices.Contracts.Persistence
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task<List<Course>> GetAllCoursesAsync(string userId);
        Task<Course?> GetCourseByIdAsync(int courseId);
        Task<bool> CourseExistsAsync(int courseId);
        Task SaveChanges();
        Task<Course> UpdateCourseAsync(Course course);
    }
}
