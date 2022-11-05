using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NewsAPI.Framework.UI.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            
            return View();
        }
    }
}