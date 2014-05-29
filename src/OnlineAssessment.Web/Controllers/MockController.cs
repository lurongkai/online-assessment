using System.Web.Mvc;

namespace OnlineAssessment.Web.Controllers
{
    public class MockController : Controller
    {
        //
        // GET: /Practice/
        public ActionResult Index() {
            return View();
        }
    }
}