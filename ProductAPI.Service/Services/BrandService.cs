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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _brandRepository.Delete(id);
        }

        public Brand Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _brandRepository.Select(id);
        }

        public IList<Brand> Get() => _brandRepository.SelectBrands();

        public Brand Post<V>(Brand obj) where V : AbstractValidator<Brand>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _brandRepository.Insert(obj);
            return obj;
        }

        public Brand Put<V>(Brand obj) where V : AbstractValidator<Brand>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _brandRepository.Update(obj);
            return obj;
        }

        public List<BrandElement> GetBrandsAndTotalProducts() => _brandRepository.SelectBrandsWithTotalProducts();

        private void Validate(Brand obj, AbstractValidator<Brand> validator)
        {
            if (obj == null)
                throw new Exception("records not found!");

            validator.ValidateAndThrow(obj);
        }

    }
}
