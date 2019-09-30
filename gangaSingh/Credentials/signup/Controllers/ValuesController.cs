using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using signup.Models;

namespace signup.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        protected string googleplus_client_id = "432257726722-7uqkb1jsgmenfolc9vochcc80nkv5qi7.apps.googleusercontent.com";    // Replace this with your Client ID
        protected string googleplus_client_secret = "TbaakkDh9N3ZzOhQrwe-3fvY";                                                // Replace this with your Client Secret
        protected string googleplus_redirect_url = "http://localhost:5500/newpage.html";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        protected string Parameters;
        // GET api/values
        dataContext obj = new dataContext();
        [HttpGet]
        public IEnumerable<Userdetails> Get()
        {
            return obj.Userdetails.ToList();
        }

        // GET api/values/5
        
        //POST api/values
        [HttpPost]
       [Route("signup")]
       public IActionResult post([FromBody]Userdetails userdata)
        {
            // var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userdata.Password);
            // userdata.Password = hashedPassword;
            var user = obj.Userdetails.FirstOrDefault(a => a.Username==userdata.Username);

            try
            {
                if (user == null)
                {
                    obj.Userdetails.Add(userdata);
                    //obj.Studentdetails.Add(userdata.Username);
                    obj.SaveChanges();
                    return Ok("tokenIsValid");
                }
                else
                {
                    if (user.Password == userdata.Password)
                    {
                        return Ok("tokenIsValid");
                    }
                    return Ok("tokenIsInvalid");
                }
                //return BadRequest("User alredy exist");
                
            }
            catch (Exception ex)
            {
                return BadRequest("User Not added");
            }
       }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
