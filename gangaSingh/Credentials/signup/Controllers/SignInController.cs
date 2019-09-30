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
        [Authorize]
        [HttpGet]
        public string test()
        {
            return "test";
        }
        [HttpPost]
        [Route("signin")]

        public ActionResult post([FromBody]Userdetails userdata)
        {
            try
            {
                //StringValues usernameValue;
                //StringValues passwordValue;

                //Request.Headers.TryGetValue("username", out usernameValue);
                //Request.Headers.TryGetValue("password", out passwordValue);

                //String username = usernameValue.FirstOrDefault();
                //String password = passwordValue.FirstOrDefault();

                Userdetails loggedinUser = obj.Userdetails.Find(userdata.Username);
                try
                {
                    if (BCrypt.Net.BCrypt.Verify(userdata.Password, loggedinUser.Password))
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

                return Ok("200");

            }
            catch (Exception ex)
            {
                //return UnauthorizedResult();
            }
            return BadRequest();
        }
        [Route("getImage")]
        [HttpPost]
        public IActionResult samplegetImage([FromBody]Userdetails user)
        {

            try
            {
                Userdetails currentUrl = obj.Userdetails.Find(user.Username);
                String url = currentUrl.Password;
                return Ok(url);

            }
            catch (Exception ex)
            {
                //return UnauthorizedResult();
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
              expires: DateTime.Now.AddMinutes(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}