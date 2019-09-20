using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyecom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cyecom.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsController : Controller

    {
        EcomContext dc = new EcomContext();
        // GET: api/Brands
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            var a = dc.Brand.ToList();
            return a;
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            var b = dc.Brand.Find(id);
            return b;
        }

        // POST: api/Brands
        [HttpPost]
        public void Post([FromBody]Brand value)
        {
            dc.Brand.Add(value);
            dc.SaveChanges();
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public void Put(int id, int bid, [FromBody]Brand value)
        {
            Brand update = dc.Brand.Single(m => m.Pid == id);
            update.Pid = value.Pid;
            update.Bid = value.Bid;
            update.Bname = value.Bname;
            dc.SaveChanges();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = dc.Products.FirstOrDefault(e => e.Pid == id);
            dc.Products.Remove(data);
            dc.SaveChanges();
        }
    }
}
