using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oas.Controllers
{
    public class SimulationController : Controller
    {
        public ActionResult Index(string courseName, Guid examId)
        {
            return View();
        }
    }
}