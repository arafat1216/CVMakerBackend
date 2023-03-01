using AutoMapper;
using CVServices.Contracts.Persistence;
using CVServices.Contracts.Services;
using CVServices.Entities;
using CVServices.ServiceModels;

namespace CVServices
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository repository;
        private readonly IMapper mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ProjectDto> AddProject(AddProjectDto addProjectRequest)
        {
            var projectToAdd = mapper.Map<Project>(addProjectRequest);

            var response = await repository.AddProjectAsync(projectToAdd);

            return mapper.Map<ProjectDto>(response);
        }

        public async Task DeleteProject(int projectId)
        {
            var projectToDelete = await repository.GetProjectByIdAsync(projectId);

            if (projectToDelete == null)
                throw new Exceptions.ProjectNotFoundException($"Project With Id {projectId} Not Found");

            await repository.DeleteProjectAsync(projectToDelete);
        }

        public async Task<List<ProjectDto>> GetAllProjects(string userId)
        {
            var response = await repository.GetAllProjectsAsync(userId);

            return mapper.Map<List<ProjectDto>>(response);
        }

        public async Task<ProjectDto> GetProjectById(int projectId)
        {
            var project = await repository.GetProjectByIdAsync(projectId);

            if (project == null)
                throw new Exceptions.ProjectNotFoundException($"Project With Id {projectId} Not Found");

            return mapper.Map<ProjectDto>(project);

        }

        public async Task<ProjectDto> UpdateProject(ProjectDto updateProjectRequest)
        {
            var projectExists = await repository.ProjectExistsAsync(updateProjectRequest.Id);

            if (!projectExists)
                throw new Exceptions.ProjectNotFoundException($"Project With Id {updateProjectRequest.Id} Not Found");

            var projectToUpdate = mapper.Map<Project>(updateProjectRequest);

            var response = await repository.UpdateProjectAsync(projectToUpdate);

            return mapper.Map<ProjectDto>(response);
        }
    }
}
