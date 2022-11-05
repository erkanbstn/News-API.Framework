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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Delete(User p)
        {
            _userDal.Delete(p);
        }

        public User Find(int id)
        {
            return _userDal.Find(id);
        }

        public User GetBySlug(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetBySlug(filter);
        }

        public void Insert(User p)
        {
            _userDal.Insert(p);
        }

        public List<User> List()
        {
            return _userDal.List();
        }

        public List<User> List(Expression<Func<User, bool>> filter)
        {
            return _userDal.List(filter);
        }

        public User LoginUser(string username, string password)
        {
            return _userDal.LoginUser(username,password);  
        }

        public void Update(User p)
        {
            _userDal.Update(p);
        }
    }
}
