using ProductAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Tests.EntityBuilder
{
   public abstract class BrandBuilderBuilder
   {
        public static System.Collections.Generic.List<Brand> GetTestBrands()
        {
            var testBrands = new List<Brand>();
            testBrands.Add(new Brand { Id = 1, Name = "Brand1" });
            testBrands.Add(new Brand { Id = 2, Name = "Brand2" });
            testBrands.Add(new Brand { Id = 3, Name = "Brand3" });
            testBrands.Add(new Brand { Id = 4, Name = "Brand4" });

            return testBrands;
        }

        public static Brand GetTestBrand()
        {
            Brand brand = new Brand
            {
                Id = 1,
                Name = "Brand1"
            };

            return brand;
        }
    }
}
