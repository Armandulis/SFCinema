using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Model
{
    public class Order
    {
        public int id { get; set; }
        public string movie { get; set; }
        public string food { get; set; }
    }
}
