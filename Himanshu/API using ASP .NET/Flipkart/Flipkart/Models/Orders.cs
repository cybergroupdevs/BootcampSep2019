using System;
using System.Collections.Generic;

namespace Flipkart.Models
{
    public partial class Orders
    {
        public int Price { get; set; }
        public int? Quantity { get; set; }
        public string Pname { get; set; }
        public int BrandId { get; set; }

        public Brands Brand { get; set; }
    }
}
