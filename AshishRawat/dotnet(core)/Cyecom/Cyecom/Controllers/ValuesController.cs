using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyecom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cyecom.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        EcomContext dc = new EcomContext();
        
        // GET api/values
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            var a = dc.Products.ToList();
            return a;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Products Get(int id)
        {
            var b = dc.Products.Find(id);
            return b;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Products value)
        {
            dc.Products.Add(value);
            dc.SaveChanges();

        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Products value)
        {
            Products update = dc.Products.Single(m => m.pid == id);
            update.pid = value.pid;
            update.pname = value.pname;
            dc.SaveChanges();
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = dc.Products.FirstOrDefault(e => e.pid == id);
            dc.Products.Remove(data);
            dc.SaveChanges();
        }
    }
}
