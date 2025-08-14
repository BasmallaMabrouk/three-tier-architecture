using System.ComponentModel.DataAnnotations;

namespace three_tier_architecture.Models
{
    public class Employee
    {
        

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int age { get; set; }
        public int NationalId { get; set; }
    }
}
