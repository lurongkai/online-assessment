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
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "Student, Teacher")]
        public ActionResult Dashboard() {
            return View();
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}