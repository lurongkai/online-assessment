using System.Web.Mvc;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService) {
            _courseService = courseService;
        }

        [Authorize(Roles = "Student, Teacher")]
        public ActionResult Index(string courseId) {
            var currentCourse = _courseService.GetCourse(courseId);
            return View(currentCourse);
        }

        [Authorize(Roles = "Student")]
        [ChildActionOnly]
        public ActionResult PinnedSubjects(string courseId) {
            var subjects = _courseService.GetCourseSubjects(courseId);
            return PartialView("_pinnedSubjects", subjects);
        }
    }
}