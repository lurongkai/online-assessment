using System;
using System.Web.Mvc;
using Oas.Service.Interfaces;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class EvaluatingController : Controller
    {
        private readonly IAnsweringService _answeringService;

        public EvaluatingController(IAnsweringService answeringService) {
            _answeringService = answeringService;
        }

        public ActionResult List(string subjectKey, Guid examinationId) {
            var unevaluatedAnswers = _answeringService.GetAllUnevaluatedAnswers(examinationId);
            return View(unevaluatedAnswers);
        }

        public ActionResult Evalute(string subjectKey, Guid examinationId, Guid answerSheetId, Guid answerId, int score) {
            _answeringService.EvaluatingAnswer(answerSheetId, answerId, score);

            return RedirectToAction("List", new {subjectKey = subjectKey, examinationId = examinationId});
        }
    }
}