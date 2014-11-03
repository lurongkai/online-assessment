using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oas.Domain;
using Oas.Domain.Service;

namespace Oas.Service.Interfaces
{
    public interface ISimulationService
    {
        Paper GeneratePaper(string courseId, string style);
    }
}
