using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}