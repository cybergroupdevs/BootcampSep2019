using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using signup.Models;

namespace signup.Controllers
{
    public class SignInController : Controller
    {
        dataContext obj = new dataContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("signin")]
        public ActionResult post([FromBody]Userdetails userdata)
        {
            var row = obj.Userdetails.SingleOrDefault(r => r.Username == userdata.Username);
            if (row.Username == userdata.Username && row.Password == userdata.Password)
            {
                return Ok("user Found");
            }
            return Unauthorized();
          
        }
    }
}