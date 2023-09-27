using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityDBFirstMVCProject.Controllers
{
    [AllowAnonymous]
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult UserLogin()
        {
            return View();
        }
    }
}