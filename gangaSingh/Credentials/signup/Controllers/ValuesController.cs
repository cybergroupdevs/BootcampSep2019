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
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/values
        [HttpPost]
       // [Route("signup")]
        public string post([FromBody]Userdetails userdata)
        {  
            obj.Userdetails.Add(userdata);
            obj.SaveChanges();
            return "success";
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
