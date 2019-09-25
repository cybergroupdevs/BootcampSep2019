using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employabilityTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employabilityTest.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class loginController : Controller
    {
        EmployeetestContext obj = new EmployeetestContext();
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
        public IActionResult Post([FromBody] Signup value)
        {
            var row = obj.Signup.SingleOrDefault(r => r.Username == value.Username);
            if(row.Username==value.Username && row.Password==value.Password)
            {
                return Ok("user in database");
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
