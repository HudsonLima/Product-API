using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infra.Data.Repository;

namespace ProductAPI.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _productRepository.Select(id);
        }

        public IQueryable<Object> Get() => _productRepository.SelectProducts();

        public Product Post<V>(Product product) where V : AbstractValidator<Product>
        {
            Validate(product, Activator.CreateInstance<V>());

            _productRepository.Insert(product);
            return product;
        }

        public Product Put<V>(Product product) where V : AbstractValidator<Product>
        {
            Validate(product, Activator.CreateInstance<V>());

            _productRepository.Update(product);
            return product;
        }

        public int Count()
        {
            return _productRepository.CountActiveProducts();
        }

        private void Validate(Product obj, AbstractValidator<Product> validator)
        {
            if (obj == null)
                throw new Exception("records not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
