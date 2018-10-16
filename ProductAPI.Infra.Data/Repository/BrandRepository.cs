using System;
using System.Collections.Generic;
using System.Text;
using ProductAPI.Domain.Entities;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infra.Data.Context;
using System.Linq;
using System.Xml.Linq;

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

        public IQueryable<Object> SelectBrands()
        {
            return from b in context.Set<Brand>()
                   select new
                   {
                       id = b.Id,
                       name = b.Name,
                       products = context.Product.Where(x => x.Brand_Id == b.Id).Count()
                  };

         /*   XElement xml = new XElement("Brands",
                from brand in context.Set<Brand>().AsEnumerable()
                orderby brand.Id
                select new XElement("brand",
                    new XAttribute("id", brand.Id),
                    new XElement("Name", brand.Name),
                    new XElement("Products", context.Product.Where(x => x.Brand_Id == brand.Id).Count())
                    )
                );

            return xml;*/
        }
    }
}
