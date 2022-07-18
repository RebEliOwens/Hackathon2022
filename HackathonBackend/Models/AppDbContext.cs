using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dispatcher> Dispatcher { get; set; }
        public DbSet<Drop> Drop { get; set; }
        public DbSet<Load> Load { get; set; }
        public DbSet<PayTruck> PayTruck { get; set; }
        public DbSet<Pickup> Pickup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
