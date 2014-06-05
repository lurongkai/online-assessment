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
        [HttpGet]
        public ActionResult Create(string subjectKey) {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string subjectKey, ExaminationPaperConfig config) {
            config.SubjectKey = subjectKey;
            var paperId = _examinationService.GenerateRandomExaminationPaper(config);
            return RedirectToAction("View", new { subjectKey = subjectKey, paperId = paperId });
        }

        public ActionResult Delete(Guid paperId) {
            try {
                _examinationService.DeleteExaminationPaper(paperId);
                return RedirectToAction("List");
            } catch {
                ViewBag.Message = "试卷当前不能被删除，可能正在使用";
                return RedirectToAction("List");
            }
        }

        public ActionResult View(string subjectKey, Guid paperId) {
            var paper = _examinationService.GetExaminationPaper(paperId);
            return View(paper);
        }
    }
}