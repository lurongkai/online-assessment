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

        public ActionResult List(Guid subjectId, ExaminationState state) {
            var examinations = _examinationService.GetAllExaminations(subjectId, state);
            return View(examinations);
        }

        public ActionResult Create(Guid subjectId, Guid paperId, ExaminationConfig config) {
            _examinationService.AddExamination(paperId, config);
            return RedirectToAction("List", new {subjectId = subjectId});
        }
    }
}