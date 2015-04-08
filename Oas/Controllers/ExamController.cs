using System;
using System.Web.Mvc;
using Oas.Domain.Service;
using Oas.Models.Exam;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class ExamController : Controller
    {
        private const string Paper = "CurrentPaper";
        private IExamService _examService;
        private IQuestionService _questionService;

        public ExamController(IExamService examService, IQuestionService questionService) {
            _examService = examService;
            _questionService = questionService;
        }

        public ActionResult Index(string courseId) {
            return View();
        }

        public ActionResult StartNew(string courseId, string style) {
            var paper = _examService.GeneratePaper(courseId, style);
            Session[Paper] = paper;
            return View(paper);
        }

        public ActionResult Submit(string courseId, ExamInputModel model) {
            var paper = (Paper) Session[Paper];
            var viewModel = new ExamInspectViewModel(paper, model);
            TempData["Inspect"] = viewModel;
            Session[Paper] = null;
            return RedirectToAction("Inspect");
        }

        public ActionResult Inspect(string courseId) {
            var viewModel = (ExamInspectViewModel) TempData["Inspect"];
            return View(viewModel);
        }

        public ActionResult DownloadAttachment(Guid questionId) {
            var question = _questionService.GetSubjectiveQuestion(questionId);
            return File(question.AttachmentPath, @"application/octet-stream", question.AttachmentName);
        }
    }
}