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
        private ProductRepository productRepository = new ProductRepository();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return productRepository.Select(id);
        }

        public IQueryable<Object> Get() => productRepository.SelectProducts();

        public Product Post<V>(Product obj) where V : AbstractValidator<Product>
        {
            Validate(obj, Activator.CreateInstance<V>());

            productRepository.Insert(obj);
            return obj;
        }

        public Product Put<V>(Product obj) where V : AbstractValidator<Product>
        {
            Validate(obj, Activator.CreateInstance<V>());

            productRepository.Update(obj);
            return obj;
        }

        public int Count()
        {
            return productRepository.countActiveProducts();
        }

        private void Validate(Product obj, AbstractValidator<Product> validator)
        {
            if (obj == null)
                throw new Exception("records not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
