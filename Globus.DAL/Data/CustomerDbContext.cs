using Globus.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Globus.DAL.Data
{
    public class CustomerDbContext : IdentityDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
