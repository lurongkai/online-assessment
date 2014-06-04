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

        public ActionResult List(string subjectKey) {
            ViewBag.subjectKey = subjectKey;
            var questions = _questionService.GetAllQuestion(subjectKey);

            return View(questions);
        }

        [HttpGet]
		public ActionResult Create(string subjectKey, QuestionForm questionForm) {
            ViewBag.subjectKey = subjectKey;
			ViewBag.questionForm = questionForm;
            var question = new Question();
            if (questionForm != QuestionForm.Subjective) {
                question.QuestionOptions.Add(new QuestionOption() {
                    IsRightAnswer = true,
                    Description = "Default"
                });
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(string subjectKey, Question newQuestion) {
            _questionService.AddQuestion(subjectKey, newQuestion);
            return RedirectToAction("List", new {subjectKey});
        }

        [HttpGet]
        public ActionResult Delete(string subjectKey, Guid questionId) {
            _questionService.DeleteQuestion(questionId);
            return RedirectToAction("List", new { subjectKey });
        }

        [HttpGet]
        public ActionResult Edit(string subjectKey, Guid questionId) {
            var question = _questionService.GetQuestion(questionId);
            return View(question);
        }

        [HttpPost]
        public ActionResult Edit(string subjectKey, Question editedQuestion) {
            _questionService.ModifyQuestion(editedQuestion);
            return RedirectToAction("List", new { subjectKey });
        }
    }
}