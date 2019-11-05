﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        Test_platformContext obj1 = new Test_platformContext();


        // GET: api/User
        [HttpGet]
        public IEnumerable<SignUp> Get()
        {
            return obj1.SignUp.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody]SignUp value)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(value.Password);
                value.Password = hashedPassword;
                obj1.SignUp.Add(value);
                obj1.SaveChanges();
                return Ok(true);
            }
            catch(Exception excep)
            {
                return BadRequest(excep);
            }
            //obj1.SignUp.Add(value);

            //obj1.SaveChanges();
        }
        
        // PUT: api/User/5
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
