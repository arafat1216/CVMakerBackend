namespace CVServices.ServiceModels
{
    public class AddWorkExperienceDto
    {
        public string UserId { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
