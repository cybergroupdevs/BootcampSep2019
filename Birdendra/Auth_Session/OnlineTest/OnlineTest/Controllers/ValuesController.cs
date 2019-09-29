using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        OnlineTesContext obj = new OnlineTesContext();
        private IConfiguration _config;

        public ValuesController(IConfiguration config)
        {
            _config = config;
        }

       // GET api/values
      // [Route("Get")]
       [HttpGet]
        public IEnumerable<SignUp> Get()
        {
            return obj.SignUp.ToList();
        }

        
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

                if (user.UserId.Equals(email) == true)
                {
                    bool validPassword = BCrypt.Net.BCrypt.Verify(pwd, user.Pwd);
                    if (validPassword)
                        return Ok(true);
                    else
                        return BadRequest("Wrong password");
                }
                else
                    return BadRequest("user doesnot exist");
                //try
                //{
                //    if (BCrypt.Net.BCrypt.Verify(pwd, user.Pwd))
                //    {
                //        string tokenString = GenerateJSONWebToken(user);
                //        return Ok(new { token = tokenString });
                //    }
                //    else
                //        return BadRequest("wrong password");
                //}
                //catch (Exception e)
                //{

                //    return BadRequest(e);
                //}
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            

        }
        
        [Route("sample")]
        [HttpGet]
        [Authorize]
        public IActionResult sampleAuthRoute()
        {
            try
            {
                var currentUser = HttpContext.User;
                //todo: make claims work, currently not working
                //if (currentuser.hasclaim(c => c.type == "email"))
                //{
                //    string email = currentuser.claims.firstordefault(c => c.type == "email").value;
                //}
                return Ok(new { message = "Sample page working" });

            }
            catch (Exception e)
            {
                return BadRequest("invalid sample" + e );
            }
            
        }
        private string GenerateJSONWebToken(SignUp userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("Name", userInfo.Name),
                new Claim("userId", userInfo.UserId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // DELETE api/values/5
        
    }
}
