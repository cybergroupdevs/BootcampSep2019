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
    public class BrandController : Controller
    {
        DotNetAPIContext br = new DotNetAPIContext();
        // GET: api/Brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return br.Brand.ToList();
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return br.Brand.Find(id);
        }
        
        // POST: api/Brand
        [HttpPost]
        public void Post([FromBody]Brand value)
        {
            br.Brand.Add(value);
            br.SaveChanges();
        }
        
        // PUT: api/Brand/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Brand value)
        {
            var obj = br.Brand.FirstOrDefault(b => b.BId == id);
            obj.BId = value.BId;
            obj.BName = value.BName;
            obj.PId = value.PId;
            br.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            br.Brand.Remove(br.Brand.FirstOrDefault(b => b.BId == id));
            br.SaveChanges();
        }
    }
}
