using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flipkart.CustomModels
{
    public class OrderResponse
    {
        public int Price { get; set; }
        public int? Quantity { get; set; }
        public string Pname { get; set; }
        public int BrandId { get; set; }
    }
}
