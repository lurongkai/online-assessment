using System;
using System.Security.Claims;
using System.Web.Mvc;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class ExaminationController : Controller
    {
        private IExaminationService _examinationService;
        private IAnsweringService _answeringService;

        public ExaminationController(IExaminationService examinationService, IAnsweringService answeringService) {
            _examinationService = examinationService;
            _answeringService = answeringService;
        }

        public ActionResult List(Guid subjectId) {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;

            var examinations = _examinationService.GetStudentAvailableExaminations(userId, subjectId);
            return View(examinations);
        }

        [HttpGet]
        public ActionResult Answering(Guid subjectId, Guid examinationId) {
            var examination = _examinationService.GetExamination(examinationId);
            return View(examination);
        }

        [HttpPost]
        public ActionResult Answering(Guid subjectId, Guid examinationId, AnswerSheet answerSheet) {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;

            _answeringService.UploadAnswerSheet(examinationId, userId, answerSheet);

            return RedirectToAction("List", new {subjectId = subjectId});
        }

        public ActionResult View(Guid subjectId, Guid answerSheetId) {
            var answerSheet = _answeringService.GetAnswerSheet(answerSheetId);
            return View(answerSheet);
        }
    }
}