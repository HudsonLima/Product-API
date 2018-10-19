using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAPI.Application.Controllers;
using ProductAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Domain.Interfaces;
using Moq;
using System.Linq;
using ProductAPI.Service.Validators;
using ProductAPI.Tests.EntityBuilder;

namespace ProductAPI.Tests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void Get_ShouldReturnAllProducts()
        {
            //Arrange
            var testProducts = ProductBuilder.GetTestProducts();
            var mock = new Mock<IProductService>();

            //Act
            mock.Setup(p => p.Get()).Returns(testProducts.AsQueryable());
            var controller = new ProductsController(mock.Object);
            var result = controller.Get() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        
        [TestMethod]
        public void Get_ShouldReturnCorrectProduct()
        {
            //Arrange
            Product testProduct = new Product();
            testProduct = ProductBuilder.GetTestProduct();
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
        public void Delete_ShouldReturnOk()
        {
            //Arrange
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
        public void Put_ShouldReturnOk()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Put<ProductValidator>(testProduct)).Returns(testProduct);
            var result = controller.Put(testProduct) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        
        [TestMethod]
        public void Post_ShouldReturnId()
        {
            //Arrange
            var testProduct = ProductBuilder.GetTestProduct();
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Post<ProductValidator>(testProduct)).Returns(testProduct);
            var result = controller.Post(testProduct) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void GetCount_ShouldReturnFile()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            var controller = new ProductsController(mock.Object);

            //Act
            mock.Setup(p => p.Count());
            var result = controller.GetTotalProducts() as FileContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.FileDownloadName);
            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }
            
    }
}
