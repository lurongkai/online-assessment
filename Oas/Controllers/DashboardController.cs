using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class DashboardController : Controller
    {
        private ICourseService _courseService;
        public DashboardController(ICourseService courseService) {
            _courseService = courseService;
        }
        public ActionResult Index(string courseName) {
            var userId = User.Identity.GetUserId();
            var courses = _courseService.GetStudentCourses(new Guid(userId));

            if (!courses.Any()) {
                
            }

            return View();
        }

    }
}