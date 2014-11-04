using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain.Service
{
    public class SimplePaperGenerationService : IPaperGenerationService
    {
        public IEnumerable<Guid> GenerateSingleSelectionQuestions(int count) {
            throw new NotImplementedException();
        }

        public IEnumerable<Guid> GenerateMultipleSelectionQuestions(int count) {
            throw new NotImplementedException();
        }

        public IEnumerable<Guid> GenerateSubjectiveSelectionQuestions(int count) {
            throw new NotImplementedException();
        }
    }
}
