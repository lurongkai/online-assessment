using System;
using System.Web.Mvc;

namespace Oas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index() {
            throw new NotImplementedException();
        }

        public ActionResult ChoiceCourse() {
            throw new NotImplementedException();
        }

        public ActionResult SetupCourse() {
            throw new NotImplementedException();
        }
    }
}