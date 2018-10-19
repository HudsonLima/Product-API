using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Service.Services;
using ProductAPI.Service.Validators;
using ProductAPI.Tests.EntityBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductAPI.Tests
{
    [TestClass]
    public class ProductsServiceTests
    {
        [TestMethod]
        public void Get_ShouldReturnProducts()
        {
            //Arrange
            var testProducts = ProductBuilder.GetTestProducts();
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);

            //Act
            mock.Setup(repo => repo.SelectProducts()).Returns(testProducts.AsQueryable());
            var result = service.Get();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get_ShouldReturnCorrectProduct()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);

            //Act
            mock.Setup(repo => repo.Select(testProduct.Id)).Returns(testProduct);
            var result = service.Get(testProduct.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testProduct.Id, result.Id);
        }

        [TestMethod]
        public void Delete_ShouldDeleteProduct()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);

            //Act
            mock.Setup(repo => repo.Delete(testProduct.Id));

            try
            {
                service.Delete(testProduct.Id);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        
        [TestMethod]
        public void Count_ShouldReturnCountTotalProducts()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);

            //Act
            mock.Setup(repo => repo.CountActiveProducts());
            var result = service.Count();

            //Assert
            Assert.IsNotNull(result);
        }
                
        [TestMethod]
        public void Update_ShouldReturnUpdatedProduct()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);

            //Act
            mock.Setup(repo => repo.Update(testProduct));
            var result = service.Put<ProductValidator>(testProduct);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testProduct.Id, result.Id);
            Assert.IsInstanceOfType(result, typeof(Product));
        }

        [TestMethod]
        public void Post_ShouldReturnCreatedProduct()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);

            //Act
            mock.Setup(repo => repo.Insert(testProduct));
            var result = service.Post<ProductValidator>(testProduct);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testProduct.Id, result.Id);
            Assert.IsInstanceOfType(result, typeof(Product));
        }
    }
}
