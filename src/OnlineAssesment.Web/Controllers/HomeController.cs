using OnlineAssesment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAssesment.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            if (User.IsInRole("Admin")) {
                return RedirectToAction("Index", "Admin");
            }

            if (User.IsInRole("Teacher")) {
                return RedirectToAction("Index", "Teacher");
            }

            if (User.IsInRole("Student")) {
                return RedirectToAction("Index", "Student");
            }

            throw new InvalidOperationException("Invalid user role.");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}