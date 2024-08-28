using BillingSystem.Models;

using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Data
{
    public class CustomerContext: DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }  
        public DbSet<AdminModel> Admins { get; set; }

        public DbSet<Mobile> Mobile { get; set; }

        public DbSet<Electricity> Electricity { get; set; }
    
    }


}
