using System;
using System.Collections.Generic;
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
            ViewBag.ExaminationType = new List<SelectListItem> {
                new SelectListItem {Value = "SimulationExam", Text = "模拟考试"},
                new SelectListItem {Value = "TheoryExam", Text = "模块化理论考试"},
                new SelectListItem {Value = "SkillExam", Text = "模块化拓展技能考试"},
                new SelectListItem {Value = "SkillExtensionExam", Text = "模块化拓展技能考试"}
            };
            return View();
        }

        [HttpPost]
        public ActionResult Create(string subjectKey, ExaminationPaperConfig config) {
            config.SubjectKey = subjectKey;
            var paperId = _examinationService.GenerateRandomExaminationPaper(config);
            return RedirectToAction("List");
            // return RedirectToAction("View", new { subjectKey = subjectKey, paperId = paperId });
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