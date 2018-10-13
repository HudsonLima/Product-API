using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
    public interface IService<Entity> where Entity : BaseEntity
    {
        Entity Post<V>(Entity obj) where V : AbstractValidator<Entity>;

        Entity Put<V>(Entity obj) where V : AbstractValidator<Entity>;

        void Delete(int id);

        Entity Get(int id);

        IList<Entity> Get();
    }
}
