using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
       
        [HttpGet]
        [Route("get")]
        public async Task<string> Get()
        {
            return "GetMethodInvoked";
        }

    }
}
