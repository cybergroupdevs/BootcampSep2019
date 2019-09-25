using System;
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class SignUp
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string CollegeName { get; set; }
        public string CollegeId { get; set; }
    }
}
