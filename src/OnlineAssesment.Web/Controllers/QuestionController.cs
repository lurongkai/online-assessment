using OnlineAssesment.Domain;
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

        public ActionResult Index(int? courseLevel)
        {
            return RedirectToAction("List", courseLevel ?? 1);
        }

        public ActionResult List(int courseLevel = 1) {
            if (courseLevel < 1 || courseLevel > 3) {
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.CourseLevel = courseLevel;
            var level = ParseCourseLevel(courseLevel);
            var questions = _questionService.GetAllQuestion(level);

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

        public ActionResult CreateQuestion(int courseLevel, QuestionType questionType) {
            return View();
        }

        private CourseLevel ParseCourseLevel(int courseLevel) {
            if (courseLevel == 1) { return CourseLevel.CoursewareDesignerLevel1; }
            if (courseLevel == 2) { return CourseLevel.CoursewareDesignerLevel2; }
            if (courseLevel == 3) { return CourseLevel.CoursewareDesignerLevel3; }

            throw new ArgumentException("courseLevel");
        }
	}
}