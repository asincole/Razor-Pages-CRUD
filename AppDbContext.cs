using Microsoft.EntityFrameworkCore;

namespace razor_pages
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers {get; set;}
    }
}