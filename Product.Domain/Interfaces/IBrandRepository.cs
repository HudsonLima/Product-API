using System;
using System.Collections.Generic;
using System.Text;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Domain.Interfaces
{
    public interface IBrandRepository
    {
        void Insert(Brand obj);

        void Update(Brand obj);

        void Delete(int id);

        Brand Select(int id);

        IList<Brand> Select();
    }
}
