using System;
using System.Collections.Generic;
using System.Text;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infra.Data.Context;
using System.Linq;

namespace ProductAPI.Infra.Data.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private SqlServerContext context = new SqlServerContext();

        public void Insert(Brand obj)
        {
            context.Set<Brand>().Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<Brand>().Remove(Select(id));
            context.SaveChanges();
        }
             
        public Brand Select(int id)
        {
            return context.Set<Brand>().Find(id);
        }

        public IList<Brand> Select()
        {
            return context.Set<Brand>().ToList();
        }

        public void Update(Brand obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
