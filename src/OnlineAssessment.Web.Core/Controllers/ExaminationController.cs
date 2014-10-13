using System;
using System.Security.Claims;
using OnlineAssessment.Domain;
using OnlineAssessment.Service;
using OnlineAssessment.Web.Core.Models.Examination;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class ExaminationController : Controller
    {
        private readonly IAnsweringService _answeringService;
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService examinationService, IAnsweringService answeringService) {
            _examinationService = examinationService;
            _answeringService = answeringService;
        }

        public ActionResult List(string subjectKey) {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;

            var examinations = _examinationService.GetStudentAvailableExaminations(userId, subjectKey);
            return View(examinations);
        }

        [HttpGet]
        public ActionResult Answering(string subjectKey, Guid examinationId) {
            var examination = _examinationService.GetExamination(examinationId);
            return View(examination);
        }

        [HttpPost]
        public ActionResult Answering(string subjectKey, Guid examinationId, AnswerSheet answerSheet) {
            var identity = User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;

            _answeringService.UploadAnswerSheet(examinationId, userId, answerSheet);

            return RedirectToAction("List", new {subjectKey = subjectKey});
        }

        public ActionResult View(string subjectKey, Guid answerSheetId) {
            var answerSheet = _answeringService.GetAnswerSheet(answerSheetId);
            // TODO: do calculation.
            var viewModel = new ExaminationResultViewModel();
            return View(viewModel);
        }
    }
}