using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Domain.Interfaces
{
    public interface IProductService
    {
        Product Post<V>(Product obj) where V : AbstractValidator<Product>;

        Product Put<V>(Product obj) where V : AbstractValidator<Product>;

        void Delete(int id);

        Product Get(int id);

        IQueryable<Object> Get();

        int Count();
    }
}
