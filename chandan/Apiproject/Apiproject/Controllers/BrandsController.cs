using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apiproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiproject.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsController : Controller
    {
        // GET: api/Brands
        ChandanContext c = new ChandanContext();
        [HttpGet]
        public IEnumerable<Brands> Get()
        {
            var itm = c.Brands.ToList();
            return itm;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public Brands Get(int id)
        {
            var x = c.Brands.Find(id);
            return x;
        }
        
        // POST: api/Brands
        [HttpPost]
        public void Post([FromBody]Brands value)
        {
            c.Brands.Add(value);
            c.SaveChanges();
        }
        
        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Brands value)
        {
            var w = c.Brands.FirstOrDefault(e => e.Pid == id);
            w.Pid = value.Pid;
            w.Bid = value.Bid;
            w.Bname = value.Bname;

            c.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            c.Brands.Remove(c.Brands.FirstOrDefault(e => e.Pid == id));
            c.SaveChanges();
        }
    }
}
