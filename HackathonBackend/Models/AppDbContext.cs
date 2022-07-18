using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Models
{
    public class AppDbContext : DbContext
    {
        //context goes here

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Drops> Drops { get; set; }
        public DbSet<Loads> Loads { get; set; }
        public DbSet<PayTruck> PayTruck{ get; set; }
        public DbSet<Pickups> Pickups { get; set; }
        public DbSet<Driver> Driver{ get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
