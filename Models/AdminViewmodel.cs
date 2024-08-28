using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Models
{
    public class AdminViewmodel
    {
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
