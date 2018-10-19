using ProductAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Tests.EntityBuilder
{
    public abstract class ProductBuilder
    {

        public static System.Collections.Generic.List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { Id = 1, Name = "Demo1", Unit = "Unit1", Quantity = 1, Price = 1, Active = true, Brand_Id = 1 });
            testProducts.Add(new Product { Id = 2, Name = "Demo2", Unit = "Unit2", Quantity = 2, Price = 2, Active = true, Brand_Id = 1 });
            testProducts.Add(new Product { Id = 3, Name = "Demo3", Unit = "Unit3", Quantity = 3, Price = 3, Active = true, Brand_Id = 1 });
            testProducts.Add(new Product { Id = 4, Name = "Demo4", Unit = "Unit4", Quantity = 4, Price = 4, Active = true, Brand_Id = 1 });

            return testProducts;
        }

        public static Product GetTestProduct()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Demo1",
                Unit = "Unit1",
                Quantity = 1,
                Price = 1,
                Active = true,
                Brand_Id = 1
            };

            return product;
        }
    }
}
