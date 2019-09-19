using System.Collections.Generic;
using System.Linq;
using Apiproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apiproject.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders1")]
    public class Orders1Controller : Controller
    {
        // GET: api/Orders1
        ChandanContext order = new ChandanContext();
        [HttpGet]
        public IEnumerable<Orders1> Get()
        {
            var itm = order.Orders1.ToList();
            return itm;
        }

        // GET: api/Orders1/5
        [HttpGet("{id}")]
        public Orders1 Get(int id)
        {
            var x = order.Orders1.Find(id);
            return x;
        }
        
        // POST: api/Orders1
        [HttpPost]
        public void Post([FromBody]Orders1 value)
        {
            order.Orders1.Add(value);
            order.SaveChanges();
        }
        
        // PUT: api/Orders1/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Orders1 value)
        {
            var w = order.Orders1.FirstOrDefault(e => e.Pname == id);
            w.Bid = value.Bid;
            w.Pname = value.Pname;
            w.Quantity = value.Quantity;
            w.Price = value.Price;

            order.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            order.Orders1.Remove(order.Orders1.FirstOrDefault(e => e.Pname == id));
            order.SaveChanges();
        }
    }
}
