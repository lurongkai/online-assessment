using System;
using System.Web.Mvc;
using Oas.Domain;
using Oas.Models.Subject;
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
            var subjects = _courseService.GetCourseSubjects(courseId);
            var viewModel = new SubjectViewModel(subjects);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(string courseId) {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string courseId, Subject subject) {
            _courseService.CreateSubject(courseId, subject);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string courseId)
        {
            _courseService.DeleteSubject(courseId);
            return RedirectToAction("Index");
        }
    }
}