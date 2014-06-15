using OnlineAssessment.Domain;
using OnlineAssessment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class ExaminationManageController : Controller
    {
        private IExaminationService _examinationService;
        public ExaminationManageController(IExaminationService examinationService) {
            _examinationService = examinationService;
        }

        public ActionResult List(string subjectKey, ExaminationState state = ExaminationState.Active) {
            var examinations = _examinationService.GetAllExaminations(subjectKey, state);
            return View(examinations);
        }
        [HttpGet]
        public ActionResult Create(string subjectKey, Guid paperId)
        {
            ViewBag.paperId = paperId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(string subjectKey, Guid paperId, ExaminationConfig config) {
            _examinationService.AddExamination(subjectKey, paperId, config);
            return RedirectToAction("List", new {subjectKey = subjectKey});
        }

        public ActionResult Active(string subjectKey, Guid examinationId)
        {
            _examinationService.ActiveExamination(examinationId);
            return RedirectToAction("List", new { subjectKey = subjectKey });
        }

        public ActionResult Archive(string subjectKey, Guid examinationId)
        {
            _examinationService.ArchiveExamination(examinationId);
            return RedirectToAction("List", new { subjectKey = subjectKey });
        }
    }
}