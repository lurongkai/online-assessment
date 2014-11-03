using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oas.Service.Interfaces;

namespace Oas.Controllers
{
    public class SimulationController : Controller
    {
        private ISimulationService _simulationService;
        public SimulationController(ISimulationService simulationService) {
            _simulationService = simulationService;
        }

        public ActionResult Index(string courseId) {
            return View();
        }

        public ActionResult StartNew(string courseId, string style) {
            throw new NotImplementedException();
        }

        public ActionResult Submit(string courseId, object something) {
            throw new NotImplementedException();
        }

        public ActionResult Inspect(string courseId) {
            throw new NotImplementedException();
        }
    }
}