using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreJWTAuth.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult GetPerson()
        {
            return Ok(new { name = "Nirab", Address = "Mirpur" });
        }
    }
}