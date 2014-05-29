using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembershipService _membershipService;

        public HomeController(IMembershipService membershipService) {
            _membershipService = membershipService;
        }

        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            return RedirectToAction("Dashboard");
        }

        [Authorize(Roles = "Student, Teacher")]
        public ActionResult Dashboard() {
            var userId = (string) Session["UserId"];
            ApplicationUser profile = _membershipService.GetProfile(userId);
            ViewBag.Profile = profile;

            return View();
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult Contact() {
            return View();
        }
    }
}