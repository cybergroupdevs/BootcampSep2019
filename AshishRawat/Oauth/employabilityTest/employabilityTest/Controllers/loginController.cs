using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employabilityTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

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
        public IActionResult Post([FromBody] dynamic value)
        {
            try
            {
                StringValues emailValue;
                StringValues passwordValue;
                Request.Headers.TryGetValue("username", out emailValue);
                Request.Headers.TryGetValue("password", out passwordValue);
                String username = emailValue.FirstOrDefault();
                String password = passwordValue.FirstOrDefault();
                Signup loggedinUser = obj.Signup.Find(username);
                var hashedPassword = loggedinUser.Password;
                bool validPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

                try
                {
                    if (validPassword == true)
                    {
                        return Ok(true);
                    }
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                }
            }
            catch
            {

            }
            return BadRequest();
        }
        

        //var row = obj.Signup.SingleOrDefault(r => r.Username == value.Username);
        //if(row.Username==value.Username && row.Password==value.Password)
        //{
        //    return Ok("user in database");
        //}
        //return Unauthorized();



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
