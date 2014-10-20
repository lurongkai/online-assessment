using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oas.Domain;
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
            return View();
        }

        [Authorize(Roles = "Student")]
        [ChildActionOnly]
        public ActionResult PinnedSubjects(string courseId) {
            //var pinnedSubjects = _courseService.GetCoursePinSubjects(courseId);
            var pinnedSubjects = new List<SubjectPin>() {
                new SubjectPin{SubjectId = Guid.NewGuid(), PinName = "Pin1"},
                new SubjectPin{SubjectId = Guid.NewGuid(), PinName = "Pin2"},
                new SubjectPin{SubjectId = Guid.NewGuid(), PinName = "Pin3"}
            };
            return PartialView("Shared/_pinnedSubjects", pinnedSubjects);
        }
    }
}