using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{

    [Route("api/SignUp")]
    public class SignUpController : Controller
    {
        // GET: api/SignUp
        OnlineTesContext obj = new OnlineTesContext();
        [HttpGet]
        public IEnumerable<SignUp> Get()
        {
            var list = obj.SignUp.ToList();
            if (list.Count() > 0)
            {
                return list;
            }
            else
                return null;
        }

        // GET: api/SignUp/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
       [HttpPost]
        public IActionResult Signup([FromBody]SignUp value)
        {
            try
            {

                value.Pwd = BCrypt.Net.BCrypt.HashPassword(value.Pwd);

                var check_obj = obj.SignUp.Find(value.UserId);

                if (check_obj == null)
                {
                    obj.SignUp.Add(value);
                    obj.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    return BadRequest("user already exist");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        // POST: api/SignUp
        
        
        // PUT: api/SignUp/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
