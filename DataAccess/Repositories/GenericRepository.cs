using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using var context = new DataContext();
            context.Add(entity);
            context.SaveChanges();

        }

        public void Delete(T entity)
        {
            using var context = new DataContext();
            context.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new DataContext();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var context = new DataContext();
            return context.Set<T>().Find(id);
            
        }

        public void Update(T entity)
        {
            using var context = new DataContext();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
