using System;
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService) {
            _questionService = questionService;
        }

        public ActionResult List(Guid subjectId) {
            ViewBag.SubjectId = subjectId;
            var questions = _questionService.GetAllQuestion(subjectId);

            return View(questions);
        }

        [HttpGet]
		public ActionResult Create(Guid subjectId, QuestionForm questionForm) {
            ViewBag.SubjectId = subjectId;
			ViewBag.questionForm = questionForm;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Guid subjectId, Question newQuestion) {
            _questionService.AddQuestion(subjectId, newQuestion);
            return RedirectToAction("List", new {subjectId});
        }

        [HttpGet]
        public ActionResult Delete(Guid subjectId, Guid questionId) {
            _questionService.DeleteQuestion(questionId);
            return RedirectToAction("List", new { subjectId });
        }

        [HttpGet]
        public ActionResult Edit(Guid subjectId, Guid questionId) {
            var question = _questionService.GetQuestion(questionId);
            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(Guid subjectId, Question editedQuestion) {
            _questionService.ModifyQuestion(editedQuestion);
            return RedirectToAction("List", new { subjectId });
        }
    }
}