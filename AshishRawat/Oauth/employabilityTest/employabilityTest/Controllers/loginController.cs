using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using employabilityTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace employabilityTest.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class loginController : Controller
    {
        EmployeetestContext obj = new EmployeetestContext();
        private IConfiguration _config;

        public loginController(IConfiguration config)
        {
            _config = config;
        }
        // GET: api/login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/login
        [HttpPost]
        public IActionResult Post([FromBody] dynamic value)
        {
            try
            {
                StringValues emailValue;
                StringValues passwordValue;
                Request.Headers.TryGetValue("username", out emailValue);
                Request.Headers.TryGetValue("password", out passwordValue);
                String username = emailValue.FirstOrDefault();
                String password = passwordValue.FirstOrDefault();
                Signup loggedinUser = obj.Signup.Find(username);
                var hashedPassword = loggedinUser.Password;
                bool validPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

                try
                {
                    if (validPassword == true)
                    {
                        
                        String tokenString = GenerateJSONWebToken(loggedinUser);
                        return Ok(new { token = tokenString });
                    }
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                }
            }
            catch
            {

            }
            return BadRequest();
        }
        

        //var row = obj.Signup.SingleOrDefault(r => r.Username == value.Username);
        //if(row.Username==value.Username && row.Password==value.Password)
        //{
        //    return Ok("user in database");
        //}
        //return Unauthorized();



        // PUT: api/login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [Route("sample")]
        [HttpGet]
        [Authorize]
        public IActionResult sampleAuthRoute()
        {
            try
            {
                var currentUser = HttpContext.User;
                //TODO: Make claims work, currently not working
                //if (currentUser.HasClaim(c => c.Type == "Email"))
                //{
                //    String email = currentUser.Claims.FirstOrDefault(c => c.Type == "Email").Value;
                //}
                return Ok(new { });

            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        private string GenerateJSONWebToken(Signup userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim("username", userInfo.Username),
        new Claim("collegename", userInfo.Collegename),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

