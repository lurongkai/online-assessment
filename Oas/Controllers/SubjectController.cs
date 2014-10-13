using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oas.Controllers
{
    public class SubjectController : Controller
    {
        public ActionResult Index(string courseName) {
            return View();
        }

        public ActionResult List(string courseName) {
            throw new NotImplementedException();
        }

        public ActionResult Create(string courseName) {
            throw new NotImplementedException();
        }

        public ActionResult PinCourse(string courseName, Guid courseId) {
            throw new NotImplementedException();
        }
    }
}