using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testportal.Models;

namespace testportal.Controllers
{
    [Route("api/[controller]")]
    public class SignupController : Controller
    {
        onlinetestportalContext obj = new onlinetestportalContext();
        private string hashedPassword;

        // GET api/Signup
        [HttpGet]
        public IEnumerable<Table1> Get()
        {
            var itm = obj.Table1.ToList();
            return itm;
        }

        // GET api/Signup/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Signup
        [HttpPost]
        public IActionResult Post([FromBody] Table1 value)
        {
         try
            {
               // hashedPassword = BCrypt.Net.BCrypt.HashPassword(value.Password);
                //value.Password = hashedPassword;
                obj.Table1.Add(value);
                obj.SaveChanges();
                return Ok(value);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // PUT api/Signup/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Signup/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
