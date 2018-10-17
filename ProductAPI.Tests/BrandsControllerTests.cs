using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductAPI.Application.Controllers;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductAPI.Tests
{
    [TestClass]
    public class BrandsControllerTests
    {
        [TestMethod]
        public void GetAllBrands_ShouldReturnAllProducts()
        {
            //Arrange
            var testBrands = GetTestBrands();
            List<Brand> brands = new List<Brand>();
            brands = GetTestBrands();
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
        public void GetBrand_ShouldReturnCorrectBrand()
        {
            //Arrange
            Brand testBrand = new Brand();
            testBrand = GetTestBrand();
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
        public void DeleteBrand_ShouldReturnOk()
        {
            //Arrange
            Brand testBrand = new Brand();
            testBrand = GetTestBrand();
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
        public void PutProduct_ShouldReturnOk()
        {
            //Arrange
            Brand testBrand = new Brand();
            testBrand = GetTestBrand();
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

            //Act
            mock.Setup(p => p.Put<BrandValidator>(GetTestBrand())).Returns(testBrand);
            var result = controller.Put(GetTestBrand()) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void PostBrand_ShouldReturnId()
        {
            //Arrange
            Brand testBrand = new Brand();
            testBrand = GetTestBrand();
            var mock = new Mock<IBrandService>();
            var controller = new BrandsController(mock.Object);

            //Act
            mock.Setup(p => p.Post<BrandValidator>(GetTestBrand())).Returns(testBrand);
            var result = controller.Post(GetTestBrand()) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(1, result.Value);
        }


        private System.Collections.Generic.List<Brand> GetTestBrands()
        {
            var testBrands = new List<Brand>();
            testBrands.Add(new Brand { Id = 1, Name = "Marca1"});
            testBrands.Add(new Brand { Id = 2, Name = "Marca2" });
            testBrands.Add(new Brand { Id = 3, Name = "Marca3" });
            testBrands.Add(new Brand { Id = 4, Name = "Marca4" });

            return testBrands;
        }

        private Brand GetTestBrand()
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
