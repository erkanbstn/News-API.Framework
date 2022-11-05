using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        AppDbContext appDb = new AppDbContext();
        DbSet<T> _object;

        public Repository()
        {
            _object = appDb.Set<T>();
        }
        public void Delete(T p)
        {
            var deleteEntity = appDb.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            appDb.SaveChanges();
        }

        public T Find(int id)
        {
           return _object.Find(id);
        }

        public T GetBySlug(Expression<Func<T, bool>> filter)
        {
            return _object.FirstOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addEntity = appDb.Entry(p);
            addEntity.State = EntityState.Added;
            appDb.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updateEntity = appDb.Entry(p);
            updateEntity.State = EntityState.Modified;
            appDb.SaveChanges();
        }
    }
}
