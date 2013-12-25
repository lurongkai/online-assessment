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

        public ActionResult List(int courseLevel) {
            if (courseLevel < 1 || courseLevel > 3) {
                return RedirectToAction("Index", "Home");
            }

            var level = ParseCourseLevel(courseLevel);
            var questions = _questionService.GetAllQuestion(level);

            return View(questions);
        }

        private CourseLevel ParseCourseLevel(int courseLevel) {
            if (courseLevel == 1) { return CourseLevel.CoursewareDesignerLevel1; }
            if (courseLevel == 2) { return CourseLevel.CoursewareDesignerLevel2; }
            if (courseLevel == 3) { return CourseLevel.CoursewareDesignerLevel3; }

            throw new ArgumentException("courseLevel");
        }
	}
}