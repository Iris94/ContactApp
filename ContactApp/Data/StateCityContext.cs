using Microsoft.EntityFrameworkCore;
using ContactApp.Models;

namespace ContactApp.Data
{
    public class StateCityContext(DbContextOptions<StateCityContext> options) : DbContext(options)
    {
        public DbSet<StateDb> States { get; set; }
        public DbSet<CityDb> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityDb>()
                .HasOne(c => c.StateDb)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateID);
        }
    }
}
