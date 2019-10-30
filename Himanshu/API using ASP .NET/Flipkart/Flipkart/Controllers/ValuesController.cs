using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flipkart.CustomModels;
using Flipkart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flipkart.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        shopping_cartContext db = new shopping_cartContext();

        // GET api/values
        [HttpGet]
        public IEnumerable<BrandResponse> Get()
        {
            
            var items = db.Brands.Select(s => new BrandResponse() { BrandId = s.BrandId , BrandName = s.BrandName});
            return items;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //return "value";
            var items = db.Brands.Find(id);
            return items.BrandName;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Brands value)
        {
            db.Brands.Add(value);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BrandResponse value)
        {
            var entity = db.Brands.FirstOrDefault(e => e.BrandId == id);
            entity.BrandId = value.BrandId;
            entity.BrandName = value.BrandName;
            db.SaveChanges();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var items = db.Brands.Find(id);
            db.Brands.Remove(items);
            db.SaveChanges();
        }
    }
}
