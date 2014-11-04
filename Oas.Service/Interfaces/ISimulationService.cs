using Oas.Domain.Service;

namespace Oas.Service.Interfaces
{
    public interface ISimulationService
    {
        Paper GeneratePaper(string courseId, string style);
    }
}