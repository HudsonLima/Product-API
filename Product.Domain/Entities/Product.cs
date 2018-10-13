using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Unity { get; set; }

        public Int32 Quantity { get; set; }

        public decimal Price { get; set; }

        public Boolean Active { get; set; }

        public Int32 Brand_Id { get; set; }

    }

}
