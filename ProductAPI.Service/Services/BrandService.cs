using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infra.Data.Repository;


namespace ProductAPI.Service.Services
{
    public class BrandService : IBrandService
    {
        private BrandRepository brandRepository = new BrandRepository();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            brandRepository.Delete(id);
        }

        public Brand Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return brandRepository.Select(id);
        }

        public IList<Brand> Get() => brandRepository.Select();

        public Brand Post<V>(Brand obj) where V : AbstractValidator<Brand>
        {
            Validate(obj, Activator.CreateInstance<V>());

            brandRepository.Insert(obj);
            return obj;
        }

        public Brand Put<V>(Brand obj) where V : AbstractValidator<Brand>
        {
            Validate(obj, Activator.CreateInstance<V>());

            brandRepository.Update(obj);
            return obj;
        }

        private void Validate(Brand obj, AbstractValidator<Brand> validator)
        {
            if (obj == null)
                throw new Exception("records not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
