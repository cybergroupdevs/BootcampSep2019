using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class loginController : Controller
    {
        Test_platformContext obj = new Test_platformContext();
        // GET: api/login
        [HttpGet]
        public IEnumerable<SignUp> Get()
        {
            return obj.SignUp.ToList();
        }

        // GET: api/login/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/login
        [HttpPost]
        public IActionResult Post([FromBody]dynamic value)
        {
            try
            {
                StringValues emailValue;
                StringValues passwordValue;
                Request.Headers.TryGetValue("Email", out emailValue);
                Request.Headers.TryGetValue("Password", out passwordValue);
                String email = emailValue.FirstOrDefault();
                String password = passwordValue.FirstOrDefault();

                SignUp loggedinUser = obj.SignUp.Find(email);
                try
                {
                    if (loggedinUser.Password.Equals(password))
                    {
                        return Ok(true);
                    }
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        //try
        //{
        //    var uname = obj.SignUp.Where(em => em.Email == value.Email).ToList();
        //    if (uname.Count() > 0)
        //    {
        //        if (uname.Exists(pwd => string.Compare(pwd.Password, value.Password) == 0))
        //            return Ok(uname);
        //        else
        //            return BadRequest("Wrong Password");
        //    }
        //    else
        //        return Unauthorized();
        //}
        //catch(Exception e)
        //{
        //    return BadRequest(e);
        //}
    }
        
         //PUT: api/login/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
  }
