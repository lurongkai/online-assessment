using Oas.Domain.Service;
using Oas.Infrastructure;
using Oas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Service.Impl
{
    public class SimulationService : ISimulationService
    {
        private OasContext _oasContext;
        public SimulationService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public Paper GeneratePaper(string courseId, string style) {
            if (style.ToLower() == "random") {
                var service = new RandomPaperGenerationService();
                //var paper = service.GeneratePaper();
            }

            if (style.ToLower() == "simple") {
                var service = new SimplePaperGenerationService();
            }

            throw new InvalidOperationException("wrong style.");
        }
    }
}
