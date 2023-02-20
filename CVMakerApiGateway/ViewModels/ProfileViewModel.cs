using System.ComponentModel.DataAnnotations;

namespace CVMakerApiGateway.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"(^(01){1}[3-9]{1}\d{8})$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNo { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
