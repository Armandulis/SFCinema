using CinemaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Data
{
    public class CinemaRepository : ICinemaRepository<Order>
    {
        private readonly CinemaApiContext db;

        public CinemaRepository(CinemaApiContext context)
        {
            db = context;
        }

        public Order Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
