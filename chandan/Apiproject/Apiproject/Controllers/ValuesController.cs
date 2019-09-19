using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apiproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apiproject.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        ChandanContext c = new ChandanContext();
        [HttpGet]
        public IEnumerable<Brands> Get()
        {
            var itm = c.Brands.ToList();
            return itm;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Brands Get(int id)
        {
            var x = c.Brands.Find(id);
            return x;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Brands value)
        {
            c.Brands.Add(value);
            c.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Brands value)
        {
            var w = c.Brands.FirstOrDefault(e => e.Pid == id);
            w.Pid = value.Pid;
            w.Bid = value.Bid;
            w.Bname = value.Bname;

            c.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            c.Brands.Remove(c.Brands.FirstOrDefault(e=>e.Pid == id));
            c.SaveChanges();
        }
    }
}
