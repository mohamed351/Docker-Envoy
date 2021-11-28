using Microsoft.EntityFrameworkCore;

namespace College.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}