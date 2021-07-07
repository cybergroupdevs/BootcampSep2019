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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        EcomContext dc = new EcomContext();
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order2> Get()
        {
            var a = dc.Order2.ToList();
            return a;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public Order2 Get(int id)
        {
            var b = dc.Order2.Find(id);
            return b;
        }

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody]Order2 value)
        {
            dc.Order2.Add(value);
            dc.SaveChanges();
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Order2 value,int Qty,int price)
        {
            Order2 update = dc.Order2.Single(m => m.Bid == id);
            update.Bid = value.Bid;
            update.Pname = value.Pname;
            update.Quantity = value.Quantity;
            update.Price = value.Price;
            dc.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = dc.Order2.FirstOrDefault(e => e.Bid == id);
            dc.Order2.Remove(data);
            dc.SaveChanges();
        }
    }
}
