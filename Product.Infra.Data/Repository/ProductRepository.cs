using System;
using System.Collections.Generic;
using System.Text;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infra.Data.Context;
using System.Linq;
using FluentValidation;

namespace ProductAPI.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private SqlServerContext context = new SqlServerContext();

        public void Insert(Product obj)
        {
            context.Set<Product>().Add(obj);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<Product>().Remove(Select(id));
            context.SaveChanges();
        }

        public Product Select(int id)
        {
            return context.Set<Product>().Find(id);
        }
        
        public IQueryable<Object> SelectProducts()
        {
            return from p in context.Set<Product>()
                   join b in context.Set<Brand>() on p.Brand_Id equals b.Id
                   where p.Active == true
                   select new
                   {
                       id = p.Id,
                       name = p.Name,
                       unit = p.Unit,
                       quantity = p.Quantity,
                       price = p.Price,
                       active = p.Active,
                       brand_Id = p.Brand_Id,
                       brand_name = b.Name
                   };
        }

        public void Update(Product obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
