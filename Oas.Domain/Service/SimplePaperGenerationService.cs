using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain.Service
{
    public class SimplePaperGenerationService : IPaperGenerationService
    {
        private QuestionTicketBag _bag;

        public SimplePaperGenerationService(QuestionTicketBag bag) {
            _bag = bag;
        }

        public IEnumerable<Guid> GenerateSingleSelectionQuestions(int count) {
            return TakeTopFitness(_bag.SingleSelectionQuestions, count);
        }

        public IEnumerable<Guid> GenerateMultipleSelectionQuestions(int count) {
            return TakeTopFitness(_bag.MultipleSelectionQuestions, count);
        }

        public IEnumerable<Guid> GenerateSubjectiveSelectionQuestions(int count) {
            return TakeTopFitness(_bag.SubjectiveQuestions, count);
        }

        private IEnumerable<Guid> TakeTopFitness(IEnumerable<QuestionTicket> questionTickets, int count) {
            if (questionTickets.Count() <= count) {
                return questionTickets.Select(q => q.QuestionId);
            }

            var candidates = new List<TicketGroup>();
            for (int i = 0; i < 50; i++) {
                var group = new TicketGroup(questionTickets.TakeRandom(count));
                candidates.Add(@group);
            }

            return candidates
                .OrderByDescending(g => g.Fitness)
                .First()
                .QuestionTickets
                .Select(q => q.QuestionId);
        }

        private class TicketGroup
        {
            private const double Expected = 0.75;
            public TicketGroup(IEnumerable<QuestionTicket> questionTickets) {
                Fitness = CalculateFitness(questionTickets);
                QuestionTickets = questionTickets;
            }

            private double CalculateFitness(IEnumerable<QuestionTicket> questionTickets) {
                if (questionTickets.Count() == 0) {
                    return 0.00;
                }

                var fitness = questionTickets.Sum(q => q.Score*q.Degree)/questionTickets.Sum(q => q.Score);
                return 1 - Math.Abs(fitness - Expected);
            }

            public double Fitness { get; private set; }
            public IEnumerable<QuestionTicket> QuestionTickets { get; private set; }
        }
    }
}
