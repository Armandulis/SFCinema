using CinemaAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data
{
    public class CinemaApiContext : DbContext
    {
        public CinemaApiContext(DbContextOptions<CinemaApiContext> options):base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
