using System;
using System.Collections.Generic;

namespace PersonalApi.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }

        public static implicit operator int(Product v)
        {
            throw new NotImplementedException();
        }
    }
}
