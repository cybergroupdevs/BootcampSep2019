using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testportal.Models;

namespace testportal.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class loginController : Controller
    {
        onlinetestportalContext obj = new onlinetestportalContext();
        // GET: api/login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/login
        [HttpPost]
        public IActionResult Post([FromBody]Table1 value)
        {
            var x = obj.Table1.SingleOrDefault(xx => xx.Username == value.Username);
            if(x.Username==value.Username&&x.Password==value.Password)
            {
                return Ok("User is allow to go further");
            }
            return Unauthorized();
        }
        
        // PUT: api/login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
