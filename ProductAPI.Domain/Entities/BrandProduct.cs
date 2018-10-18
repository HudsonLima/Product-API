using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Domain.Entities
{
    public class BrandProduct : Brand
    {
        public int TotalProducts { get; set; }
    }
}
