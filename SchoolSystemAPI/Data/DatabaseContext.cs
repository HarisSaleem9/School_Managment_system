using Microsoft.EntityFrameworkCore;

namespace SchoolSystemAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base (options){ }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Standard> standards { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
