using System;
using System.Web.Mvc;
using Oas.Domain;

namespace Oas.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        public ActionResult Index(string courseName, Guid subjectId) {
            throw new NotImplementedException();
        }

        public ActionResult List(string courseName, Guid subjectId) {
            throw new NotImplementedException();
        }

        public ActionResult Create(string courseName, Guid subjectId, Question question) {
            throw new NotImplementedException();
        }
    }
}