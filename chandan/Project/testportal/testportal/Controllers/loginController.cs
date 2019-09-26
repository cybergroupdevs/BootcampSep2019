using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using testportal.Models;

namespace testportal.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class loginController : Controller
    {
        onlinetestportalContext obj = new onlinetestportalContext();
        private IConfiguration _config;

        public loginController(IConfiguration config)
        {
            _config = config;
        }
        // GET: api/login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value11", "value22" };
        }

        // GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/login
        [HttpPost]
        public IActionResult Post([FromBody]dynamic value)
        {

            StringValues emailValue;
            StringValues passwordValue;
            Request.Headers.TryGetValue("username", out emailValue);
            Request.Headers.TryGetValue("password", out passwordValue);
            String username = emailValue.FirstOrDefault();
            String password = passwordValue.FirstOrDefault();

            Table1 loggedinUser = obj.Table1.Find(username);
            String uname = loggedinUser.Password;

            try
            {

                if (BCrypt.Net.BCrypt.Verify(password, uname))
                {
                    String tokenString = GenerateJSONWebToken(loggedinUser);
                    return Ok(new { token = tokenString });
                }
                //if (loggedinUser.Password.Equals(password))
                // {
                //    return Ok(true);
                //}
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
            return BadRequest();

        }



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
                return Ok(new { message = "Sample page working" });

            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

        private string GenerateJSONWebToken(Table1 userInfo)
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
