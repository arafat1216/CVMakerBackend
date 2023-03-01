using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CVContext context;
        private readonly DbSet<Course> db;

        public CourseRepository(CVContext context)
        {
            this.context = context;
            db = context.Set<Course>();
        }
        public async Task<Course> AddCourseAsync(Course course)
        {
            await db.AddAsync(course);

            await SaveChanges();

            return course;
        }

        public async Task<bool> CourseExistsAsync(int courseId)
        {
            return await db.AnyAsync(c => c.Id == courseId);
        }

        public async Task DeleteCourseAsync(Course course)
        {
            db.Remove(course);

            await SaveChanges();
        }

        public async Task<List<Course>> GetAllCoursesAsync(string userId)
        {
            return await db.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
        {
            return await db.Where(c => c.Id == courseId).FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            db.Update(course);

            await SaveChanges();

            return course;
        }
    }
}
