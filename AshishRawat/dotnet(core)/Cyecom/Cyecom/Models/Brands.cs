using System;
using System.Collections.Generic;

namespace Cyecom.Models
{
    public partial class Brands
    {
        public int Pid { get; set; }
        public int? Bid { get; set; }
        public string Bname { get; set; }

        public Brands P { get; set; }
        public Brands InverseP { get; set; }
    }
}
