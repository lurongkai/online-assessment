using System;
using System.Web.Mvc;
using Oas.Domain;

namespace Oas.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        public ActionResult Index(string courseId, Guid subjectId) {
            throw new NotImplementedException();
        }

        public ActionResult List(string courseId, Guid subjectId) {
            throw new NotImplementedException();
        }

        public ActionResult Create(string courseId, Guid subjectId, Question question) {
            throw new NotImplementedException();
        }
    }
}