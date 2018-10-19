using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Domain.Interfaces
{
    public interface IBrandService
    {
        Brand Post<V>(Brand obj) where V : AbstractValidator<Brand>;

        Brand Put<V>(Brand obj) where V : AbstractValidator<Brand>;

        void Delete(int id);

        Brand Get(int id);

        IList<Brand> Get();

        List<BrandElement> GetBrandsAndTotalProducts();
    }
}
