using System;
using System.Collections.Generic;

namespace CommerceWebsite.Models
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemPrice { get; set; }
    }
}
