using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;
using System.Web.Security;

namespace EntityDBFirstMVCProject.Controllers
{
    [AllowAnonymous]
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        MotorMaxEntities db = new MotorMaxEntities();
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Müsteriler musteri)
        {
            var UserLogin = db.Müsteriler.FirstOrDefault(x => x.MüsteriAdi == musteri.MüsteriAdi && x.MüsteriSifre == musteri.MüsteriSifre);
            if (UserLogin != null)
            {
               

                return RedirectToAction("UserDashboard", "User");
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı Adı veya Şifre Hatalı";
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