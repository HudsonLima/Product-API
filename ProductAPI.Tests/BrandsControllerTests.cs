using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductAPI.Application.Controllers;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Service.Validators;
using ProductAPI.Tests.EntityBuilder;

namespace ProductAPI.Tests
{
    [TestClass]
    public class BrandsControllerTests
    {
        
        [TestMethod]
        public void GetAllBrands_ShouldReturnAllBrands()
        {
            //Arrange
            var testBrands = BrandBuilderBuilder.GetTestBrands();
            var mock = new Mock<IBrandService>();

            //Act
            mock.Setup(p => p.Get()).Returns(testBrands);
            var controller = new BrandsController(mock.Object);
            var result = controller.Get() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Get_ShouldReturnAllBrandsAndTotalProducts()
        {
            //Arrange
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

            //Act
            mock.Setup(p => p.GetBrandsAndTotalProducts());
            var result = controller.GetBrandsAndTotalProducts() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void Get_ShouldReturnCorrectBrand()
        {
            //Arrange
            Brand testBrand = new Brand();
            testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

            //Act
            mock.Setup(p => p.Get(1)).Returns(testBrand);
            var result = controller.Get(1) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testBrand, result.Value);
        }

        [TestMethod]
        public void Delete_ShouldReturnOk()
        {
            //Arrange
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

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
            var testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

            //Act
            mock.Setup(p => p.Put<BrandValidator>(testBrand)).Returns(testBrand);
            var result = controller.Put(testBrand) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Post_ShouldReturnId()
        {
            //Arrange
            var testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

            //Act
            mock.Setup(p => p.Post<BrandValidator>(testBrand)).Returns(testBrand);
            var result = controller.Post(testBrand) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(1, result.Value);
        }
        
    }
}
