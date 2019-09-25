using System;
using System.Collections.Generic;

namespace OnlineTest.Models
{
    public partial class SignUp
    {
        public string UserId { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public string ColName { get; set; }
        public int? ColId { get; set; }
    }
}
