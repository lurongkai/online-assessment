using System;
using System.Linq;
using System.Web.Mvc;
using Oas.Models.Exercise;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class ExerciseController : Controller
    {
        private IQuestionService _questionService;

        public ExerciseController(IQuestionService questionService) {
            _questionService = questionService;
        }

        public ActionResult Index(string courseId, Guid subjectId) {
            return View();
        }

        public ActionResult Perform(string courseId, Guid subjectId, QuestionType type) {
            if (type == QuestionType.Selectable) {
                return View("PerformSelectable");
            }

            if (type == QuestionType.Subjective) {
                return View("PerformSubjective");
            }

            throw new InvalidOperationException("wrong question type");
        }

        public ActionResult GetData(string courseId, Guid subjectId, QuestionType type) {
            if (type == QuestionType.Selectable) {
                var questions = _questionService.GetAllSelectableQuestion(courseId, subjectId)
                    .Select(q => new
                    {
                        questionId = q.QuestionId,
                        body = q.Body,
                        score = q.Score,
                        options = q.Options.Select(o => new
                        {
                            content = o.Content,
                            isRight = o.IsRight
                        }).ToArray()
                    });
                return Json(questions.ToArray(), JsonRequestBehavior.AllowGet);
            }

            if (type == QuestionType.Subjective) {
                var questions = _questionService.GetAllSubjectiveQuestion(courseId, subjectId)
                    .Select(q => new
                    {
                        questionId = q.QuestionId,
                        body = q.Body,
                        score = q.Score,
                        answer = q.Answer
                    });
                return Json(questions.ToArray(), JsonRequestBehavior.AllowGet);
            }

            throw new InvalidOperationException("wrong type.");
        }
    }
}