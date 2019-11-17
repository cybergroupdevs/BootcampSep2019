using System;
using System.Collections.Generic;

namespace CommerceWebsite.Models
{
    public partial class Brands
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int? ItemId { get; set; }
    }
}
