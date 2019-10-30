using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flipkart.CustomModels;
using Flipkart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flipkart.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        shopping_cartContext db = new shopping_cartContext();

        // GET: api/Orders
        [HttpGet]
        public ObjectResult Get()
        {
            List<Orders> ord = db.Orders.ToList();
            List<Brands> brand = db.Brands.ToList();
            var record = (from o in ord
                          join b in brand on o.BrandId equals b.BrandId into table1
                          from i in table1.ToList()
                          select new
                          {
                              Pname = o.Pname,
                              Price = o.Price
                          });

            return Ok(record);
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            var items = db.Orders.Find(id);
            return items.Pname;
        }
        
        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody]Orders value)
        {
            db.Orders.Add(value);
            db.SaveChanges();
        }
        
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]OrderResponse value)
        {
            var entity = db.Orders.FirstOrDefault(e => e.BrandId == id);
            entity.Quantity = value.Quantity;
            db.SaveChanges();
        }
        
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var items = db.Orders.Find(id);
            db.Orders.Remove(items);
            db.SaveChanges();
        }
    }
}
