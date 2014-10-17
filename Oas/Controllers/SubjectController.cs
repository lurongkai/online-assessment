using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class SubjectController : Controller
    {
        private ICourseService _courseService;
        public SubjectController(ICourseService courseService) {
            _courseService = courseService;
        }

        public ActionResult Index(string courseId) {
            return RedirectToAction("List");
        }

        public ActionResult List(string courseId) {
            var subjects = _courseService.GetCourseSubjects(courseId);
            return View(subjects);
        }

        public ActionResult Create(string courseId) {
            throw new NotImplementedException();
        }

        public ActionResult PinSubject(string courseId, Guid subjectId) {
            throw new NotImplementedException();
        }
    }
}