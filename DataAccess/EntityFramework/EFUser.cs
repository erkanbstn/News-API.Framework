using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EFUser : Repository<User>, IUserDal
    {
        public User LoginUser(string username, string password)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            }
        }
    }
}
