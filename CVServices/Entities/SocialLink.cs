using System.ComponentModel.DataAnnotations;

namespace CVServices.Entities
{
    public class SocialLink
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LinkedinUrl { get; set; }
        public string GithubUrl { get; set; }
    }
}
