using System;
using System.Collections.Generic;

namespace CommerceWebsite.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int? BrandId { get; set; }
        public int? ItemId { get; set; }
    }
}
