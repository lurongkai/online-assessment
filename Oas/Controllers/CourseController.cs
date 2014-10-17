using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oas.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index() {
            return RedirectToAction("List");
        }

        public ActionResult List() {
            throw new NotImplementedException();
        }

        public ActionResult Subscribe(string courseId) {
            throw new NotImplementedException();
        }
    }
}