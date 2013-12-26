using OnlineAssesment.Domain;
using OnlineAssesment.Web.Extensions;
using OnlineAssesment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAssesment.Web.Controllers
{
    [Authorize(Roles="Teacher")]
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        public QuestionController(IQuestionService questionService) {
            _questionService = questionService;
        }

        public ActionResult Index(CourseLevel? courseLevel = null)
        {
            return RedirectToAction(
                "List", 
                new { courseLevel = courseLevel ?? CourseLevel.CoursewareDesignerLevel1 });
        }

        public ActionResult List(CourseLevel courseLevel) {            
            ViewBag.CourseLevel = courseLevel;
            var questions = _questionService.GetAllQuestion(courseLevel);

            var s = questions.ToList();
            s.Add(new Question {
                QuestionBody = "Test",
                QuestionDegree = 5,
                Chapter = new Chapter() { Title = "Chapter1" },
                QuestionType = QuestionType.SingleSelection,
                CourseLevel = CourseLevel.CoursewareDesignerLevel1
            });
            return View(s);
        }

        [HttpGet]
        public ActionResult CreateQuestion(CourseLevel courseLevel, QuestionType questionType) {
            ViewBag.CourseLevel = courseLevel;
            ViewBag.QuestionType = questionType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestion(Question newQuestion) {
            _questionService.AddQuestion(newQuestion);
            return RedirectToAction("List", new { courseLevel = newQuestion.CourseLevel });
        }
	}
}