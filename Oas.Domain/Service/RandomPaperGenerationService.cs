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
            if (_bag.SingleSelectionQuestions.Count() <= count) {
                return _bag.SingleSelectionQuestions.Select(q => q.QuestionId);
            }

            return _bag.SingleSelectionQuestions.TakeRandom(count).Select(q => q.QuestionId);
        }

        public IEnumerable<Guid> GenerateMultipleSelectionQuestions(int count) {
            if (_bag.MultipleSelectionQuestions.Count() <= count) {
                return _bag.MultipleSelectionQuestions.Select(q => q.QuestionId);
            }

            return _bag.MultipleSelectionQuestions.TakeRandom(count).Select(q => q.QuestionId);
        }

        public IEnumerable<Guid> GenerateSubjectiveSelectionQuestions(int count) {
            if (_bag.SubjectiveQuestions.Count() <= count) {
                return _bag.SubjectiveQuestions.Select(q => q.QuestionId);
            }

            return _bag.SubjectiveQuestions.TakeRandom(count).Select(q => q.QuestionId);
        }
    }

    internal static class EnumerableExtension
    {
        internal static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count) {
            var list = source.ToList();
            var random = new Random();

            var result = new List<T>();
            for (int i = 0; i < count; i++) {
                var location = random.Next(0, list.Count - i);
                var node = list[location];
                result.Add(node);
                list.Remove(node);
                list.Add(node);
            }

            return result;
        }
    }
}
