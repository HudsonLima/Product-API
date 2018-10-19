using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Service.Services;
using ProductAPI.Service.Validators;
using ProductAPI.Tests.EntityBuilder;

namespace ProductAPI.Tests
{
    [TestClass]
    public class BrandsServiceTests
    {
        [TestMethod]
        public void Get_ShouldReturnAllBrands()
        {
            //Arrange
            var testBrands = BrandBuilderBuilder.GetTestBrands();
            var mock = new Mock<IBrandRepository>();
            var service = new BrandService(mock.Object);

            //Act
            mock.Setup(repo => repo.SelectBrands()).Returns(testBrands);
            var result = service.Get();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testBrands, result);
        }

        [TestMethod]
        public void Get_ShouldReturnCorrectBrand()
        {
            //Arrange
            var testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandRepository>();
            var service = new BrandService(mock.Object);

            //Act
            mock.Setup(repo => repo.Select(testBrand.Id)).Returns(testBrand);
            var result = service.Get(testBrand.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testBrand.Id, result.Id);
        }

        [TestMethod]
        public void Delete_ShouldDeleteBrand()
        {
            //Arrange
            var testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandRepository>();
            var service = new BrandService(mock.Object);

            //Act
            mock.Setup(repo => repo.Delete(testBrand.Id));

            try
            {
                service.Delete(testBrand.Id);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Update_ShouldReturnUpdatedBrand()
        {
            //Arrange
            var testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandRepository>();
            var service = new BrandService(mock.Object);

            //Act
            mock.Setup(repo => repo.Update(testBrand));
            var result = service.Put<BrandValidator>(testBrand);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testBrand.Id, result.Id);
            Assert.IsInstanceOfType(result, typeof(Brand));
        }

        [TestMethod]
        public void Post_ShouldReturnCreatedProduct()
        {
            //Arrange
            var testBrand = BrandBuilderBuilder.GetTestBrand();
            var mock = new Mock<IBrandRepository>();
            var service = new BrandService(mock.Object);

            //Act
            mock.Setup(repo => repo.Insert(testBrand));
            var result = service.Post<BrandValidator>(testBrand);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testBrand.Id, result.Id);
            Assert.IsInstanceOfType(result, typeof(Brand));
        }

        [TestMethod]
        public void Get_ShouldReturnAllBrandsProducts()
        {
            //Arrange
            var testBrandElements = BrandProductBuilder.GetTestBrandElements();
            var mock = new Mock<IBrandRepository>();
            var service = new BrandService(mock.Object);

            //Act
            mock.Setup(repo => repo.SelectBrandsWithTotalProducts()).Returns(testBrandElements);
            var result = service.GetBrandsAndTotalProducts();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testBrandElements, result);
        }
    }
}
