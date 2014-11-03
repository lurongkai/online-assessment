using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oas.Domain;
using Oas.Models.Simulation;
using Oas.Service.Interfaces;

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
            var paper = _simulationService.GeneratePaper(courseId, style);
            var viewModel = new SimulationViewModel(paper);
            return View(viewModel);
        }

        public ActionResult Submit(string courseId, SimulationViewModel model) {
            model.Evaluate();
            TempData[Paper] = model;
            return RedirectToAction("Inspect");
        }

        public ActionResult Inspect(string courseId) {
            var model = (SimulationViewModel)TempData[Paper];
            return View(model);
        }
    }
}