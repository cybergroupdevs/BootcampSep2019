using System;
using System.Collections.Generic;

namespace Cyecom.Models
{
    public partial class Order2
    {
        public Order2()
        {
            Brand = new HashSet<Brand>();
        }

        public int Bid { get; set; }
        public string Pname { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }

        public ICollection<Brand> Brand { get; set; }
    }
}
