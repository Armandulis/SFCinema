using CinemaAPI.Model;
using System.Data.Entity;

namespace CinemaAPI.Data
{
    public class CinemaApiContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public CinemaApiContext(string connectionString):base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Order");
        }

    }
}
