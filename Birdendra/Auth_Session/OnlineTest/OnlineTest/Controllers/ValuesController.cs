using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        OnlineTesContext obj = new OnlineTesContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<SignUp> Get()
        {
            return obj.SignUp.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //public SignUp Get(string id)
        //{
           
        //}

        // POST api/values
        //[EnableCors("AllowedOrigins")]
        [HttpPost]
        public IActionResult login([FromBody]SignUp value)
        {
            try
            {
                //var val = obj.SignUp.Where(em => em.UserId == value.UserId ).ToList();
                var val = obj.SignUp.SingleOrDefault(em => em.UserId == value.UserId);

                if (val != null )
                {
                    if ( val.Pwd == value.Pwd )
                        return Ok(val);
                    else
                        return BadRequest("Wrong password");
                }
                else
                    return BadRequest("user doesnot exist");
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{user_id}")]
        public void Delete(string user_id)
        {
            try
            {
                obj.SignUp.Remove(obj.SignUp.FirstOrDefault(x => x.UserId == user_id));
                obj.SaveChanges();
            }
            catch( Exception e)
            {
                //Console.WriteLine(e);
                //Console.ReadKey();
            }

        }
    }
}
