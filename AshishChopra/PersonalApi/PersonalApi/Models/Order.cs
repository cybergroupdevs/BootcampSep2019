using System;
using System.Collections.Generic;

namespace PersonalApi.Models
{
    public partial class Order
    {
        public int Bid { get; set; }
        public string Pname { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
