using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
            return new string[] { "value11", "value22" };
        }

        // GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/login
        [HttpPost]
        public IActionResult Post([FromBody]dynamic value)
        {

            StringValues emailValue;
            StringValues passwordValue;
            Request.Headers.TryGetValue("username", out emailValue);
            Request.Headers.TryGetValue("password", out passwordValue);
            String username = emailValue.FirstOrDefault();
            String password = passwordValue.FirstOrDefault();

            Table1 loggedinUser = obj.Table1.Find(username);
            try
            {
                if (loggedinUser.Password.Equals(password))
                {
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
            return BadRequest();
        
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
