using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Models
{
    public class Electricity
    {
        [Key]
        public int Id { get; set; }
        public double meternumber { get; set; }

        public double amount { get; set; }
    }
}
