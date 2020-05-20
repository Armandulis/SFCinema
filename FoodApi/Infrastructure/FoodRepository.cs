using FoodApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Infrastructure
{
    public class FoodRepository : IFoodRepository
    {
        private readonly DBContext db;
        public FoodRepository()
        {

            db = new DBContext("Server=tcp:sfsynopsis.database.windows.net,1433;Initial Catalog=SFSynopsis;Persist Security Info=False;User ID=armandas;Password=L96h8an9a;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
        public Food Create(Food food)
        {
            db.Food.Add(food);
            db.SaveChanges();
            return food;
        }

        public void Delete(int id)
        {
            db.Food.Remove(GetFood(id));
            db.SaveChanges();
        }

        public void Edit(Food food)
        {
            // Edits food
            db.Food.Add(food);
            db.Entry(food).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        public IEnumerable<Food> GetAll()
        {
            return db.Food.ToList();
        }

        public Food GetFood(int id)
        {
            return db.Food.FirstOrDefault(p => p.Id == id);
        }

    }
}
