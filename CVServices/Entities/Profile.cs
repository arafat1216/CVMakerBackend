using System.ComponentModel.DataAnnotations;

namespace CVServices.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
}
