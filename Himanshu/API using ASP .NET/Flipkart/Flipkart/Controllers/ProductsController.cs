using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flipkart.CustomModels;
using Flipkart.Models;

namespace Flipkart.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        shopping_cartContext db = new shopping_cartContext();

        // GET: api/Products
        [HttpGet]
        public IEnumerable<ProductsResponse> Get()
        {
            var items = db.Products.Select(s => new ProductsResponse() { PId = s.PId, Pname = s.Pname });

            return items;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var items = db.Products.Find(id);
            return items.Pname;
            
        }
        
        // POST: api/Products
        [HttpPost]
        public void Post([FromBody]Products value)
        {
            db.Products.Add(value);
            db.SaveChanges();
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Products value)
        {
            var entity = db.Products.FirstOrDefault(e => e.PId == id);
            entity.Pname = value.Pname;
            db.SaveChanges();
        }
        
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var items = db.Products.Find(id);
            db.Products.Remove(items);
            db.SaveChanges();
        }
    }
}
