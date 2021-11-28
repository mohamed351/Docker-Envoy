using Microsoft.EntityFrameworkCore;

namespace HR.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
        {

        }

        public DbSet<Employees> Employees { get; set; }
    }
}