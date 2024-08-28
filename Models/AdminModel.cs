using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FiName { get; set; }
        
        [Required]
        public string LaName { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
