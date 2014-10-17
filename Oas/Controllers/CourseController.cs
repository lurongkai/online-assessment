using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View();
        }
    }
}