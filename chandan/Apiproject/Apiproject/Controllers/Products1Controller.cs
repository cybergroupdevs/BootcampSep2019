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
    [Route("api/Products1")]
    public class Products1Controller : Controller
    {
        // GET: api/Products1
        ChandanContext product = new ChandanContext();
        [HttpGet]
        public IEnumerable<Products1> Get()
        {
            var itm = product.Products1.ToList();
            return itm;
        }

        // GET: api/Products1/5
        [HttpGet("{id}")]
        public Products1 Get(int id)
        {
            var x = product.Products1.Find(id);
            return x;
        }
        
        // POST: api/Products1
        [HttpPost]
        public void Post([FromBody]Products1 value)
        {
            product.Products1.Add(value);
            product.SaveChanges();
        }
        
        // PUT: api/Products1/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Products1 value)
        {
            var w = product.Products1.FirstOrDefault(e => e.Pid == id);
            w.Pid = value.Pid;
            w.Pname = value.Pname;
           product.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            product.Products1.Remove(product.Products1.FirstOrDefault(e => e.Pid == id));
            product.SaveChanges();
        }
    }
}
