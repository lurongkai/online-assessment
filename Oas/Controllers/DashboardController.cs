using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ICourseService _courseService;
        public DashboardController(ICourseService courseService) {
            _courseService = courseService;
        }

        public ActionResult Index() {
            var userId = User.Identity.GetUserId();

            if (User.IsInRole("Admin")) { return RedirectToAction("Index", "Admin"); }
            
            if (User.IsInRole("Teacher")) {
                var course = _courseService.GetTeacherTeachCourse(new Guid(userId));
                return RedirectToAction("Index", "Course", new { courseName = course.CourseName });
            }
            
            if (User.IsInRole("Student")) {
                var courses = _courseService.GetStudentCourses(new Guid(userId)).ToList();

                if (courses.Count == 0) { return RedirectToAction("SetupCourse"); }
                if (courses.Count == 1) { return RedirectToAction("Index", "Course", new { courseName = courses[0].CourseName }); }

                return RedirectToAction("ChoiceCourse");
            }

            throw new InvalidOperationException("wrong user role.");
        }

        [Authorize(Roles = "Student")]
        public ActionResult ChoiceCourse() {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Student")]
        public ActionResult SetupCourse() {
            throw new NotImplementedException();
        }
    }
}