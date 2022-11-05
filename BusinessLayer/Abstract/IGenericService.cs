using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        List<T> List();
        T GetBySlug(Expression<Func<T, bool>> filter);
        T Find(int id);
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
