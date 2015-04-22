using System;
using System.Web.Mvc;
using Oas.Service.Interfaces;
using Oas.Service.Messages;

namespace Oas.Controllers
{
    public class EvalController : Controller
    {
        private IExamService _examService;

        public EvalController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpGet]
        public ActionResult Index(string courseId)
        {
            var unevaluatedAnswerSheet = _examService.GetUnevaluatedAnswerSheets(courseId);
            return View(unevaluatedAnswerSheet);
        }
        [HttpGet]
        public ActionResult Perform(Guid answerSheetId)
        {
            var answerSheet = _examService.GetAnswerSheet(answerSheetId);
            return View(answerSheet);
        }
        [HttpPost]
        public ActionResult Perform(Guid answerSheetId, AnswerSheetEnvaluation evaluation)
        {
            _examService.EvaluateAnswerSheet(answerSheetId, evaluation);
            TempData["SlashMessage"] = "提交成功";
            return RedirectToAction("Index");
        }
    }
}