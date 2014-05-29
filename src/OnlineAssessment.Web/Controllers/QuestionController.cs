using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService) {
            _questionService = questionService;
        }

        public ActionResult Index(Guid subjectId) {
            return RedirectToAction(
                "List",
                new {subjectId});
        }

        public ActionResult List(Guid subjectId) {
            ViewBag.SubjectId = subjectId;
            IEnumerable<Question> questions = _questionService.GetAllQuestion(subjectId);

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
        public ActionResult CreateQuestion(Guid subjectId, Question newQuestion) {
            _questionService.AddQuestion(subjectId, newQuestion);
            return RedirectToAction("List", new {subjectId});
        }
    }
}