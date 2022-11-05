using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using DataAccess.Concrete;
using System.Web.WebSockets;

namespace NewsAPI.Framework.UI.Controllers
{
    public class NewsApiController : ApiController
    {
        NewsletterManager _newsletter = new NewsletterManager(new EFNewsletter());

        [Route("api/GetNews")]
        [HttpGet]
        public IEnumerable<Newsletter> GetNewsletter()
        {
            int uid = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return _newsletter.List(x => x.UserID == uid);
        }
        [Route("api/GetNews/{id}")]
        [HttpGet]
        public Newsletter GetNewsletter(int id)
        {
            Newsletter News = _newsletter.Find(id);
            if (News == null)
            {
                return null;
            }

            return News;
        }

        // PUT api/NewsAPI/5
        [Route("api/UpdateNews")]
        [HttpPut]
        public IHttpActionResult PutNewsletter(Newsletter News)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _newsletter.Update(News);


                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/NewsAPI
        [Route("api/AddNews")]
        [HttpPost]
        public IHttpActionResult PostNewsletter(Newsletter News)
        {
            if (ModelState.IsValid)
            {
                News.Slug = News.Title.ToUpper();
                News.IsActive = true;
                _newsletter.Insert(News);

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/NewsAPI/5
        [Route("api/DeleteNews/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteNewsletter(int id)
        {
            Newsletter News = _newsletter.Find(id);
            if (News == null)
            {
                return NotFound();
            }
            News.Status = 0;
            _newsletter.Update(News);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            AppDbContext db = new AppDbContext();
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}