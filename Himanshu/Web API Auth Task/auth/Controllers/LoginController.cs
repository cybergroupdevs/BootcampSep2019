using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using auth.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace auth.Controllers
{
    [Produces("application/json")]
    [Route("login")]
    public class LoginController : Controller
    {
        auth_databaseContext db = new auth_databaseContext();

        private IConfiguration _config;
        private string tokenString;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        //Get /loginAuthentication
        [Authorize]
        [HttpGet("loginAuthentication")]
        public IActionResult Get()
        {
            try
            {
                var currentUser = HttpContext.User;
                return Ok(true);
            }
            catch(Exception e)
            {
            }
            return BadRequest();
        }


        // POST: login
        [HttpPost]
        public IActionResult Post([FromBody]UserPassword value)
        {
            var entity = db.UserPassword.Where(s => s.Username == value.Username).FirstOrDefault();

            if (entity.Username != null)
            {
                bool validPassword = BCrypt.Net.BCrypt.Verify(value.Password, entity.Password);
                if (validPassword)
                {
                    tokenString = GenerateJSONWebToken(entity);
                    return Ok(new { token = tokenString });
                }
                return BadRequest("Incorrect Username or Password");
            }
            return BadRequest("Incorrect Username or Password");
        }

        private string GenerateJSONWebToken(UserPassword userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Username",userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims, 
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
