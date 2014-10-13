using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oas.Controllers
{
    public class ExerciseController : Controller
    {
        public ActionResult Index(string courseName, Guid subjectId)
        {
            return View();
        }
    }
}