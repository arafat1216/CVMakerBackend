using System.ComponentModel.DataAnnotations;

namespace CVServices.Entities
{
    public class Summary
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
    }
}
