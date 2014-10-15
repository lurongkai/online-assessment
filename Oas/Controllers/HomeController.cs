using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICourseService _courseService;
        public HomeController(ICourseService courseService) {
            _courseService = courseService;
        }

        [AllowAnonymous]
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            var userId = User.Identity.GetUserId();

            if (User.IsInRole("Admin")) { return RedirectToAction("Index", "Admin"); }
            if (User.IsInRole("Teacher")) {
                var course = _courseService.GetTeacherTeachCourse(new Guid(userId));
                return RedirectToAction("Index", "Dashboard", new { courseName = course.CourseName });
            }
            if (User.IsInRole("Student")) {
                var courses = _courseService.GetStudentCourses(new Guid(userId)).ToList();
                
                if (courses.Count == 0) { return RedirectToAction("SetupCourse"); }
                if (courses.Count == 1) { return RedirectToAction("Index", "Dashboard", new { courseName = courses[0].CourseName });}
            
                return RedirectToAction("ChoiceCourse");
            }
            
            throw new InvalidOperationException("user role wrong.");
        }

        public ActionResult ChoiceCourse() {
            throw new NotImplementedException();
        }

        public ActionResult SetupCourse() {
            throw new NotImplementedException();
        }
    }
}