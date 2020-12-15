using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using auth.Models;
using auth.CustomModels;

namespace auth.Controllers
{
    [Produces("application/json")]
    [Route("signup")]
    public class ValuesController : Controller
    {
        auth_databaseContext db = new auth_databaseContext();
        //private string url;
        
        // POST signup
        [EnableCors("ApiCorsPolicy")]
        [HttpPost]
        public IActionResult Post([FromBody] CustomJoinedDetails val)
        {
            var entity = db.UserDetails.Where(s => s.Email == val.Email || s.Username == val.Username).ToList();

            if (entity.Count() == 0)
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(val.Password);
                UserPassword userPassword = new UserPassword
                {
                    Username = val.Username,
                    Password = hashedPassword
                };
                UserDetails userDetails = new UserDetails
                {
                    Email = val.Email,
                    CollegeId = val.CollegeId,
                    CollegeName = val.CollegeName,
                    UsernameNavigation = userPassword
                };
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
                return Ok(true);
            }
            else if (entity[0].Username == val.Username)
            {
                return BadRequest("Username already Existed");
            }
            else
            {
                return BadRequest("Email ID already Existed");
            }
        }


        [HttpPost()]
        [Route("googleDetails")]

        public CustomGoogleDetails Post([FromBody] CustomGoogleDetails value)
        {
            char[] sep = {'.'};
            string[] username = value.Email.Split(sep,2,StringSplitOptions.None);
            var entity = db.UserDetails.Where(s => s.Username == username[0]).ToList();
            if(entity.Count() == 0)
            {
                UserPassword userPassword = new UserPassword
                {
                    Username = username[0],
                    Password = value.Password
                };
                UserDetails userDetails = new UserDetails
                {
                    Username = username[0],
                    Email = value.Email

                };
                db.UserPassword.Add(userPassword);
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
                return value;
            }
            return value;
        }

        //[HttpGet()]
        //[Route("googleImage")]
        //public string Get()
        //{
        //    return url;
        //}
    }
}
