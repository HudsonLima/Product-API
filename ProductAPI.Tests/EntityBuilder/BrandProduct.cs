using ProductAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Tests.EntityBuilder
{
    public class BrandProductBuilder
    {
        public static System.Collections.Generic.List<BrandElement> GetTestBrandElements()
        {
            var testBrands = new List<BrandElement>();
            testBrands.Add(new BrandElement { Id = 1, Name = "Brand1", TotalProducts = 1 });
            testBrands.Add(new BrandElement { Id = 2, Name = "Brand2", TotalProducts = 2 });
            testBrands.Add(new BrandElement { Id = 3, Name = "Brand3", TotalProducts = 3 });
            testBrands.Add(new BrandElement { Id = 4, Name = "Brand4", TotalProducts = 4 });

            return testBrands;
        }       
    }
}
