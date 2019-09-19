using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        E_commerceContext obj = new E_commerceContext();
        //// GET api/values
        [HttpGet]
        public IEnumerable<Items> Get()
        {
            //  return new String[2] { "value1", "value2" };
            var view = obj.Items.ToList();
            return view;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Items Get(int id)
        {
            var result = obj.Items.Find(id);
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Items value)
        {
            obj.Items.Add(value);
            obj.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Items value)
        {
            Items objectItem = obj.Items.Single(i => i.ItemId == id);
            objectItem.ItemName = value.ItemName;
            objectItem.ItemPrice = value.ItemPrice;
            obj.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            obj.Items.Remove(obj.Items.FirstOrDefault(e => e.ItemId == id));
            obj.SaveChanges();
        }
    }
}