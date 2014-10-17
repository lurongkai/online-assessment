using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}