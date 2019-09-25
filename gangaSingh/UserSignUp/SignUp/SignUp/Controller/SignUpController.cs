using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignUp.Models;
using System.Web;


namespace SignUp.Controllers
{
    public class SignUpController : Controller
    {
        //UserInfoLogin UserData = new UserInfoLogin();
       // [Route("User/[controller]")]
       [Route("view")]
        public IActionResult Index()
        {
            return View();
        }
   
        [HttpPost]
        [Route("signUp")]
        public JsonResult AjaxPostCall([FromBody]UserInfoLogin UserData)
        {
            UserInfoLogin  User = new UserInfoLogin();
   
                User.UserName = UserData.UserName;
                User.Password = UserData.Password;
            return Json(User);
        }
    }
   
}