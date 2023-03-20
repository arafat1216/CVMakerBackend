namespace CVMakerApiGateway.Models
{
    public class CVDto
    {
        public ProfileDto Profile { get; set; }
        public SummaryDto Summary { get; set; }
        public List<WorkExperienceWithTasksDto> WorkExperiences { get; set; }
        public List<SkillDto> Skills { get; set; }
        public List<DegreeDto> Degrees { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
