using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAPI.Application.Controllers;
using ProductAPI.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using ProductAPI.Domain.Interfaces;
using Moq;

namespace ProductAPI.Tests
{
    [TestClass]
    public class TestProductsController
    {

      /*  [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController();

            var result = controller.Get() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
            */ 

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
         /*   var testProducts = GetTestProducts();
            var controller = new ProductsController();

            var result = controller.Get(5) as ObjectResult;


            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3], result.Value);
            */
            //Act
            

            //Assert
           

             Product product = new Product();
             product = GetTestProduct();

              ObjectResult objectResult = new ObjectResult(product);

              var mock = new Mock<IProductRepository>();
              mock.Setup(p => p.Select(5)).Returns(product);

              var controller = new ProductsController();
              var result = controller.Get(5) as ObjectResult;

              Assert.IsNotNull(result);
              Assert.AreEqual(product, result.Value);

        }

        /* [TestMethod]
         public void GetProduct_ShouldNotFindProduct()
         {
             var controller = new ProductsController();

             var result = controller.Get(9999);
             Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));
         }

         [TestMethod]
         public void PutProduct_ShouldUpdateProduct()
         {
             // Arrange  
             var controller = new ProductsController();

             Product product = new Product();
             product = GetTestProduct();

             if (product.Id > 0)
             { 
                 // Act  
                 IActionResult actionResult = controller.Put(product);
                 var contentResult = actionResult await NegotiatedContentResult<product>;
                 Assert.IsNotNull(contentResult);
                 Assert.AreEqual(HttpStatusCode.Accepted, contentResult);
                 Assert.IsNotNull(contentResult.Content);
             }
    }*/

        private System.Collections.Generic.List<Product> GetTestProducts()
            {
                var testProducts = new List<Product>();
                testProducts.Add(new Product { Id = 1, Name = "Demo1", Unit = "Unit1", Quantity = 1, Price = 1, Active = true, Brand_Id = 1 });
                testProducts.Add(new Product { Id = 2, Name = "Demo2", Unit = "Unit2", Quantity = 2, Price = 2, Active = true, Brand_Id = 1 });
                testProducts.Add(new Product { Id = 3, Name = "Demo3", Unit = "Unit3", Quantity = 3, Price = 3, Active = true, Brand_Id = 1 });
                testProducts.Add(new Product { Id = 4, Name = "Demo4", Unit = "Unit4", Quantity = 4, Price = 4, Active = true, Brand_Id = 1 });

                return testProducts;
            }

            private Product GetTestProduct()
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
