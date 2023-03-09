using System.ComponentModel.DataAnnotations;

namespace CVMakerApiGateway.ViewModels
{
    public class DegreeViewModel
    {
        [Required]
        public string Name { get; set; }
        
        public string Subject { get; set; }
        
        [Required]
        public string Institute { get; set; }
        
        [Required]
        public string StartYear { get; set; }
        
        [Required]
        public string EndYear { get; set; }
    }
}
