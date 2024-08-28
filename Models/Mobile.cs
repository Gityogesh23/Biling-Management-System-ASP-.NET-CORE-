using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Models
{
    public class Mobile
    {
        [Key]
        public int Id { get; set; }
        public double number{ get; set; }
        
        public double amount { get; set; }
    }
}
