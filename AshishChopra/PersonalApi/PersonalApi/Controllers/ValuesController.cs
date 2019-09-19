using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PersonalApi.Models;
using System.Threading.Tasks;

namespace PersonalApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ashishContext obj = new ashishContext(); 
        //ValuesController(ashishContext context)
        //{
        //    obj = context;
        //}
       
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {

            var a = obj.Product.ToList();
            return a ;

        }
        

        // GET api/values/5
        [Route("test")]
        [HttpGet("{id}")]
        public string Products(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            obj.Product.Add(value);
            obj.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product value)
        {
            Product put = obj.Product.FirstOrDefault(e =>e.Pid==id);
            put.Pid = value.Pid;
            put.Pname =value.Pname ;
            obj.SaveChanges();
         
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var a = obj.Product.Find(id);
            obj.Product.Remove(a);
            obj.SaveChanges();
        }
    }
}
