using System;
using System.Collections.Generic;
using System.Text;
using Product.Domain.Entities;

namespace Product.Domain.Interfaces
{
   public interface IRepository<Entity> where Entity : BaseEntity
   {
        void Insert(Entity obj);

        void Update(Entity obj);

        void Delete(int id);

        Entity Select(int id);

        IList<Entity> Select();
   }
}

