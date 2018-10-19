using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Domain.Entities
{
    public class BrandElement : Brand
    {
        public int TotalProducts { get; set; }
    }
}
