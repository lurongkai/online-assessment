using System;
using System.Web.Mvc;
using OnlineAssessment.Service;
using OnlineAssessment.Service.Message;

namespace OnlineAssessment.Web.Core.Controllers
{
    public class PaperController : Controller
    {
        private readonly IExaminationService _examinationService;
        public PaperController(IExaminationService examinationService) {
            _examinationService = examinationService;
        }

        public ActionResult List(Guid subjectId) {
            var allPapers = _examinationService.GetAllExaminationPapers(subjectId);
            return View(allPapers);
        }

        public ActionResult Create(Guid subjectId, ExaminationPaperConfig config) {
            var paperId = _examinationService.GenerateRandomExaminationPaper(config);
            return RedirectToAction("View", new {subjectId = subjectId, paperId = paperId});
        }

        public ActionResult View(Guid subjectId, Guid paperId) {
            var paper = _examinationService.GetExaminationPaper(paperId);
            return View(paper);
        }
    }
}