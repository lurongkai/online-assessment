using System;
using System.Web.Mvc;
using Oas.Domain.Service;
using Oas.Models.Simulation;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class SimulationController : Controller
    {
        private const string Paper = "CurrentPaper";
        private ISimulationService _simulationService;
        private IQuestionService _questionService;

        public SimulationController(ISimulationService simulationService, IQuestionService questionService) {
            _simulationService = simulationService;
            _questionService = questionService;
        }

        public ActionResult Index(string courseId) {
            return View();
        }

        public ActionResult StartNew(string courseId, string style) {
            var paper = _simulationService.GeneratePaper(courseId, style);
            Session[Paper] = paper;
            return View(paper);
        }

        public ActionResult Submit(string courseId, SimulationInputModel model) {
            var paper = (Paper) Session[Paper];
            var viewModel = new SimulationInspectViewModel(paper, model);
            TempData["Inspect"] = viewModel;
            Session[Paper] = null;
            return RedirectToAction("Inspect");
        }

        public ActionResult Inspect(string courseId) {
            var viewModel = (SimulationInspectViewModel) TempData["Inspect"];
            return View(viewModel);
        }

        public ActionResult DownloadAttachment(Guid questionId) {
            var question = _questionService.GetSubjectiveQuestion(questionId);
            return File(question.AttachmentPath, @"application/octet-stream", question.AttachmentName);
        }
    }
}