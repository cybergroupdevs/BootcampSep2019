using System;
using System.Collections.Generic;

namespace Flipkart.Models
{
    public partial class Products
    {
        public int PId { get; set; }
        public int? BrandId { get; set; }
        public string Pname { get; set; }

        public Brands Brand { get; set; }
    }
}
