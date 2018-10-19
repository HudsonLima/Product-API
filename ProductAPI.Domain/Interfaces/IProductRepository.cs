using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Domain.Interfaces
{
   public interface IProductRepository
    {
        void Insert(Product obj);

        void Update(Product obj);

        void Delete(int id);

        Product Select(int id);

        IQueryable<Object> SelectProducts();

        int CountActiveProducts();
    }
}
