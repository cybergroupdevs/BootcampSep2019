using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        OnlineTesContext obj = new OnlineTesContext();
        private IConfiguration _config;

        public ValuesController(IConfiguration config)
        {
            _config = config;
        }

      
        [HttpGet]
        [Authorize]
        [Route("Get")]
        public IEnumerable<SignUp> Get()
        {
            return obj.SignUp.ToList();
        }

        
        [HttpPost]
        [Route("login")]
        public IActionResult login([FromBody]SignUp user)
        {
            try
            {
                //var val = obj.SignUp.Where(em => em.UserId == value.UserId ).ToList();
                //StringValues emailValue;
                //StringValues pwdValue;
                //Request.Headers.TryGetValue("userId", out emailValue);
                //Request.Headers.TryGetValue("pwd", out pwdValue);
               
                //string email = obj.value.FirstOrDefault();
                //string pwd = pwdValue.FirstOrDefault();

                //SignUp user = obj.SignUp.Find(email);
                //pick user from db
                var loginedUser = obj.SignUp.Find( user.UserId);
                //check user exist or not
             
                if (user.UserId.Equals(loginedUser.UserId) == true)
                {
                    //validate password
                    try
                    {
                        if (BCrypt.Net.BCrypt.Verify(user.Pwd, loginedUser.Pwd))
                        {
                            //generate token
                            string tokenString = GenerateJSONWebToken(loginedUser);
                            return Ok(new { token = tokenString });
                        }
                        else
                            return BadRequest("Wrong password");
                    }
                    catch (Exception e )
                    {
                        return BadRequest(e);
                    }
                }
                else
                    return BadRequest("user doesnot exist");
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            

        }
        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup([FromBody]SignUp value)
        {
            try
            {

                value.Pwd = BCrypt.Net.BCrypt.HashPassword(value.Pwd);

                var check_obj = obj.SignUp.Find(value.UserId);

                if (check_obj == null)
                {
                    obj.SignUp.Add(value);
                    obj.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    return BadRequest("user already exist");
                }


            }
            catch (Exception e)
            {
                return BadRequest(e);
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
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // DELETE api/values/5
        
    }
}
