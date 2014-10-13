using System.Web.Mvc;

namespace Oas.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index(string courseName) {
            return View();
        }

    }
}