using Microsoft.EntityFrameworkCore;

namespace HackathonBackend.Models
{
    public class AppDbContext : DbContext
    {
        //context goes here

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<tblCarrier> Carrier { get; set; }
        public DbSet<tblDrops> Drops { get; set; }
        public DbSet<tblLoads> Loads { get; set; }
        public DbSet<tblPayTruck> PayTruck{ get; set; }
        public DbSet<tblPickups> Pickups { get; set; }
        public DbSet<tblDriver> Driver{ get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
