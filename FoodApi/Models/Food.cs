using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Models
{
    public class Food
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int AmountLeft { get; set; }
    }
}
