using OnlineAssessment.Domain;
using OnlineAssessment.Web.Extensions;
using OnlineAssessment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAssessment.Web.Controllers
{
    [Authorize(Roles="Teacher")]
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        public QuestionController(IQuestionService questionService) {
            _questionService = questionService;
        }

        public ActionResult Index(Guid subjectId)
        {
            return RedirectToAction(
                "List",
                new { subjectId = subjectId });
        }

        public ActionResult List(Guid subjectId) {
            ViewBag.SubjectId = subjectId;
            var questions = _questionService.GetAllQuestion(subjectId);

            return View(questions);
        }

        [HttpGet]
        public ActionResult CreateQuestion(Guid subjectId, QuestionForm questionType) {
            ViewBag.SubjectId = subjectId;
            ViewBag.QuestionType = questionType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestion(Question newQuestion) {
            _questionService.AddQuestion(newQuestion);
            return RedirectToAction("List", new { newQuestion.SubjectId });
        }
	}
}