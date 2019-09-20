using System;
using System.Collections.Generic;

namespace Cyecom.Models
{
    public partial class Brand
    {
        public int Pid { get; set; }
        public int? Bid { get; set; }
        public string Bname { get; set; }

        public Order2 B { get; set; }
    }
}
