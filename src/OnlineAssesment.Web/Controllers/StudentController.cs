using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAssesment.Web.Controllers
{
    [Authorize(Roles="Student")]
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}