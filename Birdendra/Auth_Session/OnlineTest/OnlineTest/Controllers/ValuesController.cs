using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
        public IActionResult login([FromBody]dynamic value)
        {
            try
            {
                //var val = obj.SignUp.Where(em => em.UserId == value.UserId ).ToList();
                StringValues emailValue;
                StringValues pwdValue;
                Request.Headers.TryGetValue("userId", out emailValue);
                Request.Headers.TryGetValue("pwd", out pwdValue);

                string email = emailValue.FirstOrDefault();
                string pwd = pwdValue.FirstOrDefault();

                SignUp user = obj.SignUp.Find(email);
                if ( user.UserId.Equals(email) )
                {
                    if (user.Pwd.Equals(pwd) )
                        return Ok(true);
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
