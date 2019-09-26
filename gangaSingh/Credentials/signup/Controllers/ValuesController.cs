using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using signup.Models;

namespace signup.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        dataContext obj = new dataContext();
        [HttpGet]
        public IEnumerable<Userdetails> Get()
        {
            return obj.Userdetails.ToList();
        }

        // GET api/values/5
        
        //POST api/values
        [HttpPost]
       [Route("signup")]
       public IActionResult post([FromBody]Userdetails userdata)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userdata.Password);
            userdata.Password = hashedPassword;
            try
            {
                obj.Userdetails.Add(userdata);
                //obj.Studentdetails.Add(userdata.Username);
                obj.SaveChanges();
                return Ok("User Added");
            }
            catch (Exception ex)
            {
                return BadRequest("User Not added");
            }
       }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
