using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAPI.Application.Controllers;
using ProductAPI.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Interfaces;
using Moq;
using System.Linq;
using System;
using FluentValidation;
using ProductAPI.Service.Validators;
using System.IO;

namespace ProductAPI.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            //Arrange
            var testProducts = GetTestProducts();
            List<Product> products = new List<Product>();
            products = GetTestProducts();
            var mock = new Mock<IProductService>();

            //Act
            mock.Setup(p => p.Get()).Returns(products.AsQueryable());
            var controller = new ProductsController(mock.Object);
            var result = controller.Get() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }


        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            //Arrange
            Product testProduct = new Product();
            testProduct = GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Get(1)).Returns(testProduct);
            var result = controller.Get(1) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testProduct, result.Value);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOk()
        {
            //Arrange
            Product testProduct = new Product();
            testProduct = GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Delete(1));
            var result = controller.Delete(1) as OkResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnOk()
        {
            //Arrange
            Product testProduct = new Product();
            testProduct = GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Put<ProductValidator>(GetTestProduct())).Returns(testProduct);
            var result = controller.Put(GetTestProduct()) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        [TestMethod]
        public void PostProduct_ShouldReturnId()
        {
            //Arrange
            Product testProduct = new Product();
            testProduct = GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Post<ProductValidator>(GetTestProduct())).Returns(testProduct);
            var result = controller.Post(GetTestProduct()) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void GetCountProduct_ShouldReturnFile()
        {
            //Arrange
            Product testProduct = new Product();
            testProduct = GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Count());
            var result = controller.productCount() as FileContentResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.FileDownloadName);
            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }

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
