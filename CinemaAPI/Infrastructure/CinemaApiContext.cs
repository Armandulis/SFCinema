using CinemaAPI.Model;
using System.Data.Entity;

namespace CinemaAPI.Infrastructure
{
    public class CinemaApiContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public CinemaApiContext(string connectionString) : base(connectionString)
        {
        }

    }
}
