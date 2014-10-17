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

        public ActionResult Index(string courseId) {
            throw new NotImplementedException();
        }
    }
}