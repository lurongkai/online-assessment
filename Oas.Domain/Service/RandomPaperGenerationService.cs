using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain.Service
{
    public class RandomPaperGenerationService : IPaperGenerationService
    {
        private QuestionTicketBag _bag;

        public RandomPaperGenerationService(QuestionTicketBag bag) {
            _bag = bag;
        }

        public IEnumerable<Guid> GenerateSingleSelectionQuestions(int count) {
            return TakeRandomCount(_bag.SingleSelectionQuestions, count);
        }

        public IEnumerable<Guid> GenerateMultipleSelectionQuestions(int count) {
            return TakeRandomCount(_bag.MultipleSelectionQuestions, count);
        }

        public IEnumerable<Guid> GenerateSubjectiveSelectionQuestions(int count) {
            return TakeRandomCount(_bag.SubjectiveQuestions, count);
        }

        private IEnumerable<Guid> TakeRandomCount(IEnumerable<QuestionTicket> questionTickets, int count) {
            if (questionTickets.Count() <= count) {
                return questionTickets.Select(q => q.QuestionId);
            }

            return questionTickets.TakeRandom(count).Select(q => q.QuestionId);
        }
    }
}
