using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        INewsletterDal _NewsletterDal;

        public NewsletterManager(INewsletterDal NewsletterDal)
        {
            _NewsletterDal = NewsletterDal;
        }

        public void Delete(Newsletter p)
        {
            _NewsletterDal.Delete(p);
        }

        public Newsletter Find(int id)
        {
            return _NewsletterDal.Find(id);
        }

        public Newsletter GetBySlug(Expression<Func<Newsletter, bool>> filter)
        {
            return _NewsletterDal.GetBySlug(filter);
        }

        public void Insert(Newsletter p)
        {
            _NewsletterDal.Insert(p);
        }

        public List<Newsletter> List()
        {
            return _NewsletterDal.List();
        }

        public List<Newsletter> List(Expression<Func<Newsletter, bool>> filter)
        {
            return _NewsletterDal.List(filter);
        }

        public void Update(Newsletter p)
        {
            _NewsletterDal.Update(p);
        }
    }
}
