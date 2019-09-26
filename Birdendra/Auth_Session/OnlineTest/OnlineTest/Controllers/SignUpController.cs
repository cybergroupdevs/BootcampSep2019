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
    [Produces("application/json")]
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
        
        // POST: api/SignUp
        [HttpPost]
        public IActionResult Post([FromBody]SignUp value)
        {
            try
            {
                
                string hashPwd = BCrypt.Net.BCrypt.HashPassword(value.Pwd);
                SignUp user = new SignUp();
                user.UserId = value.UserId;
                user.Pwd = hashPwd;
                user.Name = value.Name;
                user.ColName = value.ColName;
                user.ColId = value.ColId;

                var check_obj = obj.SignUp.Find(value.UserId);

                if (check_obj == null)
                {
                    obj.SignUp.Add(user);
                    obj.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    return BadRequest("user already exist");
                }
                

            }
            catch( Exception e)
            {
                return BadRequest(e);
            }

        }
        
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
