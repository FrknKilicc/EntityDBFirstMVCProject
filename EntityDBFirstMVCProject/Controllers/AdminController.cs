using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDBFirstMVCProject.Models;

namespace EntityDBFirstMVCProject.Controllers
{
    [Authorize(Roles = "A,B")]
    public class AdminController : Controller
    {
        MotorMaxEntities db = new MotorMaxEntities();
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            var result = db.Admins.ToList();
            return View(result);
        }
       

    }
}