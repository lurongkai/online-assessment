using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Domain.Application;
using Oas.Service.Interfaces;
using Oas.Service.Messages;

namespace Oas.Controllers
{
    public class HomeController : Controller
    {
        private IManagementService _managementService;
        public HomeController(IManagementService managementService) {
            _managementService = managementService;
        }

        [AllowAnonymous]
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                //var topNews = _managementService.GetTopNews(1);
                var topNews = new News() { Title = "T1", Content = "C1" };
                return View(topNews);
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