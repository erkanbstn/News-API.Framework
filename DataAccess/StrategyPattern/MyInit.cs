using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            User user = new User()
            {
                FullName = "Erkan Bostan",
                UserName = "erkanbstn",
                Password = "123",
                Slug="ERKANBOSTAN"
            };
            User user2 = new User()
            {
                FullName = "Acer Pro",
                UserName = "acerpro",
                Password = "123",
                Slug="ACERPRO"
            };
            context.Users.Add(user);
            context.Users.Add(user2);
            context.SaveChanges();

            Newsletter news = new Newsletter()
            {
                Title = "Acer Haber",
                Description = "Acer Açıklama",
                UserID = 2,
                Slug="ACER HABER",
                IsActive = true
            };
            Newsletter news2 = new Newsletter()
            {
                Title = "Test Haber",
                Description = "Test Açıklama",
                UserID = 1,
                Slug = "TEST HABER",
                IsActive = true
            };
            context.Newsletters.Add(news);
            context.Newsletters.Add(news2);
            context.SaveChanges();
        }
    }
}
