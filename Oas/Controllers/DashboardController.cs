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
        private IManagementService _managementService;
        public DashboardController(ICourseService courseService, IManagementService managementService) {
            _courseService = courseService;
            _managementService = managementService;
        }

        public ActionResult Index() {
            var userId = User.Identity.GetUserId();

            if (User.IsInRole("Admin")) { return RedirectToAction("Index", "Admin"); }

            if (User.IsInRole("Teacher")) {
                var course = _courseService.GetTeacherTeachCourse(new Guid(userId));
                return RedirectToAction("Index", "Dashboard", new { courseId = course.CourseId });
            }

            if (User.IsInRole("Student")) {
                var myCourses = _courseService.GetStudentCourses(new Guid(userId)).ToArray();
                return View(myCourses);
            }

            throw new InvalidOperationException("wrong user role");
        }

        [Authorize(Roles = "Student")]
        public ActionResult Subscribe() {
            var userId = User.Identity.GetUserId();
            var allCourses = _courseService.GetAllCourses();
            var studentCourses = _courseService.GetStudentCourses(new Guid(userId));
            var available = allCourses.Intersect(studentCourses);

            return View(available);
        }

        [Authorize(Roles = "Student")]
        public ActionResult Subscribe(string courseId) {
            var userId = User.Identity.GetUserId();
            _managementService.SubscribeCourse(new Guid(userId), courseId);
            return RedirectToAction("Index", "Dashboard", new { courseId = courseId });
        }
    }
}