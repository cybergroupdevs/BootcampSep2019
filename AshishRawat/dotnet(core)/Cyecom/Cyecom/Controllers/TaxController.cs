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
    [Route("api/Tax")]
    public class TaxController : Controller
    {
       EcomContext dc = new EcomContext();
        // GET: api/Tax
        [HttpGet]
        public IEnumerable<Tax> Get()
        {
            var a = dc.Tax.ToList();
            return a;
        }

        // GET: api/Tax/5
        [HttpGet("{id}")]
        public Tax Get(int id)
        {
            var b = dc.Tax.Find(id);
            return b;
        }

        // POST: api/Tax
        [HttpPost]
        public void Post([FromBody]Tax value)
        {
            dc.Tax.Add(value);
            dc.SaveChanges();
        }

        // PUT: api/Tax/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Tax value)
        {
            Tax update = dc.Tax.Single(m => m.Pid == id);
            update.Pid = value.Pid;
            update.Gst = value.Gst;
            dc.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = dc.Tax.FirstOrDefault(e => e.Pid == id);
            dc.Tax.Remove(data);
            dc.SaveChanges();
        }
    }
}
