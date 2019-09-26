using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using signup.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace signup.Controllers
{
    public class SignInController : Controller
    {
        dataContext obj = new dataContext();
        private IConfiguration _config;

        public SignInController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("signin")]
        
        public ActionResult post([FromHeader]dynamic userdata)
        {
            //var row = obj.Userdetails.SingleOrDefault(r => r.Username == userdata.Username);
            //if (row.Username == userdata.Username && row.Password == userdata.Password)
            //{
            //    return Ok("user Found");
            //}
            //return Unauthorized();
            try
            {
                StringValues usernameValue;
                StringValues passwordValue;
                Request.Headers.TryGetValue("username", out usernameValue);
                Request.Headers.TryGetValue("password", out passwordValue);

                String username = usernameValue.FirstOrDefault();
                String password = passwordValue.FirstOrDefault();

                Userdetails loggedinUser = obj.Userdetails.Find(username);
                try
                {
                    if (BCrypt.Net.BCrypt.Verify(password, loggedinUser.Password))
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
            catch (Exception ex)
            {

            }
            return BadRequest();

        }

        //private string GenerateJSONWebToken(Userdetails loggedinUser)
        //{
        //    throw new NotImplementedException();
        //}
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

        private string GenerateJSONWebToken(Userdetails userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim("username", userInfo.Username),
            new Claim("password", userInfo.Password),
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