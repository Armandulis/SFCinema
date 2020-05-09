using FoodApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Infrastructure
{
    public interface IFoodRepository
    {

        // Create
        Food Create(Food food);

        // Read
        Food GetFood(int id);
        IEnumerable<Food> GetAll();

        // Update
        void Edit(Food food);

        // Delete
        void Delete(int id);
    }
}
