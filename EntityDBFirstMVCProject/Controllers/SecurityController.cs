using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;
using System.Web.Security;
using System.Web.Services.Description;

namespace EntityDBFirstMVCProject.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        MotorMaxEntities db = new MotorMaxEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var userlogin = db.Admins.FirstOrDefault(x => x.Name == admin.Name && x.Passwordd == admin.Passwordd);
            if (userlogin != null)
            {
                FormsAuthentication.SetAuthCookie(userlogin.Name, true);
                
                return RedirectToAction("AdminDashboard", "Admin");

            }
            else
            {
                ViewBag.MessageBox = "Kullanıcı Adı veya Şifre Yanlış";

                return View();

            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}