using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THE_BLOCKCHAIN.Controllers
{
    public class testcontroller: Controller 
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new { name = "Nick" });
        }
    }
}
