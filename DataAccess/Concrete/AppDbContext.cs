using DataAccess.StrategyPattern;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext")
        {
            Database.SetInitializer(new MyInit());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
    }

}
