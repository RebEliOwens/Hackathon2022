using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Models
{
    public class AppDbContext : DbContext
    {
        //context goes here

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
