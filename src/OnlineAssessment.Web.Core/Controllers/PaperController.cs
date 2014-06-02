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

        public ActionResult List(string subjectKey) {
            var allPapers = _examinationService.GetAllExaminationPapers(subjectKey);
            return View(allPapers);
        }

        public ActionResult Create(string subjectKey, ExaminationPaperConfig config) {
            var paperId = _examinationService.GenerateRandomExaminationPaper(config);
            return RedirectToAction("View", new {subjectKey = subjectKey, paperId = paperId});
        }

        public ActionResult View(string subjectKey, Guid paperId) {
            var paper = _examinationService.GetExaminationPaper(paperId);
            return View(paper);
        }
    }
}