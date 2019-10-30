using System;
using System.Collections.Generic;

namespace auth.Models
{
    public partial class UserDetails
    {
        public string CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public UserPassword UsernameNavigation { get; set; }
    }
}
