using Microsoft.EntityFrameworkCore;
using SampleCrudApp.Models;

namespace SampleCrudApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<RunTracker> RunTracker { get; set; }
    }
}
