using System.Web.Mvc;

namespace Oas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index() {
            if (!User.Identity.IsAuthenticated) {
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}