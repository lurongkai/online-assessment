using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain.Service
{
    public interface IPaperGenerationService
    {
        IEnumerable<Guid> GenerateSingleSelectionQuestions(int count);
        IEnumerable<Guid> GenerateMultipleSelectionQuestions(int count);
        IEnumerable<Guid> GenerateSubjectiveSelectionQuestions(int count);
    }
}
