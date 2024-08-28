using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; } 

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
