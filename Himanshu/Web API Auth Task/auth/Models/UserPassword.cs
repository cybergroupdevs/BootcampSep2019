using System;
using System.Collections.Generic;

namespace auth.Models
{
    public partial class UserPassword
    {
        public UserPassword()
        {
            UserDetails = new HashSet<UserDetails>();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<UserDetails> UserDetails { get; set; }
    }
}
