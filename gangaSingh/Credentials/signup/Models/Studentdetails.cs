using System;
using System.Collections.Generic;

namespace signup.Models
{
    public partial class Studentdetails
    {
        public string Username { get; set; }
        public string Collegeid { get; set; }
        public string Collegename { get; set; }
        public string Email { get; set; }

        public Userdetails UsernameNavigation { get; set; }
    }
}
