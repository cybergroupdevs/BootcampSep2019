using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        DotNetAPIContext oc = new DotNetAPIContext();
        //private object Order;

        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var val = oc.Order.ToList();

            return val;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return oc.Order.Find(id);
        }
        
        // POST: api/Order
        [HttpPost]
        public void Post([FromBody]Order value)
        {
            oc.Order.Add(value);
            oc.SaveChanges();
        }
        
        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Order value)
        {
            var obj = oc.Order.FirstOrDefault(o => o.BId == id);
            obj.BId = value.BId;
            obj.PName = value.PName;
            oc.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            oc.Order.Remove(oc.Order.FirstOrDefault(o => o.BId == id));
            oc.SaveChanges();
        }
    }
}
