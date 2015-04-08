using Oas.Domain.Service;

namespace Oas.Service.Interfaces
{
    public interface IExamService
    {
        Paper GeneratePaper(string courseId, string style);
    }
}