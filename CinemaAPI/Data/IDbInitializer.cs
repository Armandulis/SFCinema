using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Data
{
    public interface IDbInitializer
    {
        void Initialize(CinemaApiContext context);
    }
}
