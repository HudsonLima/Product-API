using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(Entity obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        T Get(int id);

        IList<T> Get();
    }
}
