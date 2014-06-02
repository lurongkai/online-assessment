using System;
using System.Web.Mvc;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class EvaluatingController : Controller
    {
        private IAnsweringService _answeringService;
        public EvaluatingController(IAnsweringService answeringService) {
            _answeringService = answeringService;
        }
        public ActionResult List(Guid subjectId, Guid examinationId) {
            var unevaluatedAnswers = _answeringService.GetAllUnevaluatedAnswers(examinationId);
            return View(unevaluatedAnswers);
        }

        public ActionResult Evalute(Guid subjectId, Guid examinationId, Guid answerSheetId, Guid answerId, int score) {
            _answeringService.EvaluatingAnswer(answerSheetId, answerId, score);

            return RedirectToAction("List", new {subjectId = subjectId, examinationId = examinationId});
        }
    }
}