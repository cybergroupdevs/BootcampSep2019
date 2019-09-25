using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employabilityTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace employabilityTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        EmployeetestContext et = new EmployeetestContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<Signup> Get()
        {
            var obj = et.Signup.ToList();
            return obj;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Signup value)
        {
            try
            {
                et.Signup.Add(value);
                et.SaveChanges();
                return Ok(value);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
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
