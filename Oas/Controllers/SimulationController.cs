using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oas.Domain;
using Oas.Domain.Service;
using Oas.Models.Simulation;
using Oas.Service.Interfaces;
using SubjectiveQuestion = Oas.Domain.SubjectiveQuestion;

namespace Oas.Controllers
{
    public class SimulationController : Controller
    {
        private const string Paper = "CurrentPaper";
        private ISimulationService _simulationService;
        public SimulationController(ISimulationService simulationService) {
            _simulationService = simulationService;
        }

        public ActionResult Index(string courseId) {
            return View();
        }

        public ActionResult StartNew(string courseId, string style) {
            //var paper = _simulationService.GeneratePaper(courseId, style);
            var paper = new Paper();
            paper.SingleQuestions.Add(new SelectableQuestion() {
                QuestionId = Guid.NewGuid(),
                Body = "test single",
                Options = new List<Option>() {
                    new Option(){OptionId = Guid.NewGuid(),Content = "single1-true", IsRight = true},
                    new Option(){OptionId = Guid.NewGuid(),Content = "single2-false", IsRight = false},
                    new Option(){OptionId = Guid.NewGuid(),Content = "single3-false", IsRight = false},
                    new Option(){OptionId = Guid.NewGuid(),Content = "single4-false", IsRight = false}
                }
            });
            paper.MultipleQuestions.Add(new SelectableQuestion() {
                QuestionId = Guid.NewGuid(),
                Body = "test multiple",
                Options = new List<Option>() {
                    new Option(){OptionId = Guid.NewGuid(),Content = "multiple1-true", IsRight = true},
                    new Option(){OptionId = Guid.NewGuid(),Content = "multiple2-false", IsRight = false},
                    new Option(){OptionId = Guid.NewGuid(),Content = "multiple3-true", IsRight = true},
                    new Option(){OptionId = Guid.NewGuid(),Content = "multiple4-false", IsRight = false}
                }
            });
            paper.SubjectiveQuestions.Add(new SubjectiveQuestion() {
                QuestionId = Guid.NewGuid(),
                Body = "test subjective",
                Answer = "test answer"
            });
            Session[Paper] = paper;

            return View(paper);
        }

        public ActionResult Submit(string courseId, SimulationInputModel model) {
            var paper = (Paper)Session[Paper];
            var viewModel = new SimulationInspectViewModel(paper, model);
            TempData["Inspect"] = viewModel;
            return RedirectToAction("Inspect");
        }

        public ActionResult Inspect(string courseId) {
            var viewModel = (SimulationInspectViewModel)TempData["Inspect"];
            return View(viewModel);
        }
    }
}