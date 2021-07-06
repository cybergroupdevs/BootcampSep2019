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
    [Route("api/Taxes")]
    public class TaxesController : Controller
    {
        // GET: api/Taxes
        ChandanContext tax = new ChandanContext();
        [HttpGet]
        public IEnumerable<Taxes> Get()
        {
            var itm = tax.Taxes.ToList();
            return itm;
        }

        // GET: api/Taxes/5
        [HttpGet("{id}")]
        public Taxes Get(int id)
        {
            var x = tax.Taxes.Find(id);
            return x;
        }
        
        // POST: api/Taxes
        [HttpPost]
        public void Post([FromBody]Taxes value)
        {
            tax.Taxes.Add(value);
            tax.SaveChanges();
        }
        
        // PUT: api/Taxes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Taxes value)
        {
            var w = tax.Taxes.FirstOrDefault(e => e.Pid == id);
            w.Pid = value.Pid;
            w.Gst = value.Gst;
            tax.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tax.Taxes.Remove(tax.Taxes.FirstOrDefault(e => e.Pid == id));
            tax.SaveChanges();
        }
    }
}
