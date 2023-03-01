using CVServices.Contracts.Persistence;
using CVServices.Entities;
using CVServices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly CVContext context;
        private readonly DbSet<Project> db;

        public ProjectRepository(CVContext context)
        {
            this.context = context;
            db = context.Set<Project>();
        }
        public async Task<Project> AddProjectAsync(Project project)
        {
            await db.AddAsync(project);

            await SaveChanges();

            return project;
        }

        public async Task DeleteProjectAsync(Project project)
        {
            db.Remove(project);

            await SaveChanges();
        }

        public async Task<List<Project>> GetAllProjectsAsync(string userId)
        {
            return await db.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int projectId)
        {
            return await db.Where(p => p.Id == projectId).FirstOrDefaultAsync();
        }

        public async Task<bool> ProjectExistsAsync(int projectId)
        {
            return await db.AnyAsync(p => p.Id == projectId);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            db.Update(project);

            await SaveChanges();

            return project;
        }
    }
}
