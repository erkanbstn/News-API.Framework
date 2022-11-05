using BusinessLayer.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Runtime.InteropServices;
using System.Web.Security;

namespace NewsAPI.Framework.UI.Controllers
{
    public class UserApiController : ApiController
    {
        UserManager _userManager = new UserManager(new EFUser());

        [Route("api/UserControl")]
        [HttpPost]
        public IHttpActionResult UserControl(User user)
        {
            var control = _userManager.LoginUser(user.UserName, user.Password);
            if (control == null)
            {
                return NotFound();
            }
            FormsAuthentication.SetAuthCookie(control.Id.ToString(), false);
            return Ok();
        }
        [Route("api/GetUsers")]
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userManager.List();
        }
        [Route("api/FindUser")]
        [HttpGet]
        public string FindUsers()
        {
            int uid = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return _userManager.Find(uid).FullName;
        }
    }
}