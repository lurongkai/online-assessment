using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class HomeController : Controller
    {
        private ICourseService _courseService;
        private IManagementService _managementService;
        public HomeController(ICourseService courseService, IManagementService managementService) {
            _courseService = courseService;
            _managementService = managementService;
        }

        [AllowAnonymous]
        public ActionResult Index() {
            if (User.Identity.IsAuthenticated) {
                var userId = User.Identity.GetUserId();

                if (User.IsInRole("Admin")) { return RedirectToAction("Index", "Admin"); }

                if (User.IsInRole("Teacher")) {
                    var course = _courseService.GetTeacherTeachCourse(new Guid(userId));
                    return RedirectToAction("Index", "Dashboard", new {courseId = course.CourseId});
                }

                if (User.IsInRole("Student")) {
                    var courses = _courseService.GetStudentCourses(new Guid(userId)).ToArray();

                    if (courses.Length == 0) { return RedirectToAction("SetupCourse"); }
                    if (courses.Length == 1) { return RedirectToAction("Index", "Dashboard", new {courseId = courses[0].CourseId}); }

                    return RedirectToAction("ChoiceCourse");
                }
            }

            return View();
        }

        [Authorize(Roles = "Student")]
        public ActionResult ChoiceCourse() {
            var userId = User.Identity.GetUserId();
            var courses = _courseService.GetStudentCourses(new Guid(userId));

            return View(courses);
        }

        [Authorize(Roles = "Student")]
        public ActionResult SetupCourse() {
            var userId = User.Identity.GetUserId();
            var courses = _courseService.GetAllSubjects();
            var studentCourses = _courseService.GetStudentCourses(new Guid(userId));
            var available = courses.Intersect(studentCourses);

            return View(available);
        }

        [Authorize(Roles = "Student")]
        public ActionResult SetupCourse(string courseId) {
            var userId = User.Identity.GetUserId();
            _managementService.SubscribeCourse(new Guid(userId), courseId);
            return RedirectToAction("Index", "Dashboard", new {courseId = courseId});
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}