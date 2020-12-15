using System;
using System.Collections.Generic;

namespace Flipkart.Models
{
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public Orders Orders { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
