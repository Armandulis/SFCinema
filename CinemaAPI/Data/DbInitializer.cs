using CinemaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Data
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(CinemaApiContext context)
        {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (context.Orders.Any())
                {
                    return;  
                }

                List<Order> orders = new List<Order>
            {
                new Order { id = 1, food = "Salty popcorn", movie = "Star Wars" },
                new Order { id = 2, food = "Sandwich", movie = "Fast n Furious" },
                new Order { id = 3, food = "Sushi", movie = "Lord of the rings" }
            };

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
    }
}
