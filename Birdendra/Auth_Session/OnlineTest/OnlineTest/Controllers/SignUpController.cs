using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    [Produces("application/json")]
    [Route("api/SignUp")]
    public class SignUpController : Controller
    {
        // GET: api/SignUp
        OnlineTesContext obj = new OnlineTesContext();
        [HttpGet]
        public IEnumerable<SignUp> Get()
        {
            return obj.SignUp.ToList();
        }

        // GET: api/SignUp/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/SignUp
        [HttpPost]
        public IActionResult Post([FromBody]SignUp value)
        {
            try
            {
                obj.SignUp.Add(value);
                obj.SaveChanges();
                return Ok(value);
            }
            catch( Exception e)
            {
                return BadRequest(e);
            }

        }
        
        // PUT: api/SignUp/5
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
