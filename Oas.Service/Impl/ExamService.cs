using System;
using System.Linq;
using Oas.Domain.Service;
using Oas.Infrastructure;
using Oas.Service.Interfaces;

namespace Oas.Service.Impl
{
    public class ExamService : IExamService
    {
        private OasContext _oasContext;

        public ExamService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public Paper GeneratePaper(string courseId, string style) {
            var bag = new QuestionTicketBag();
            bag.SingleSelectionQuestions = _oasContext.SelectableQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Where(q => q.Options.Count(o => o.IsRight) == 1)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            bag.MultipleSelectionQuestions = _oasContext.SelectableQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Where(q => q.Options.Count(o => o.IsRight) > 1)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            bag.SubjectiveQuestions = _oasContext.SubjectiveQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            
            var singleCount = 20;
            var multipleCount = 20;
            var subjectiveCount = 5;

            IPaperGenerationService service = null;
            if (style.ToLower() == "random") {
                service = new RandomPaperGenerationService(bag);
                singleCount = 0;
                multipleCount = 0;
            }
            if (style.ToLower() == "simple") {
                service = new SimplePaperGenerationService(bag);
                subjectiveCount = 0;
            }

            if (service == null) {
                throw new InvalidOperationException("wrong style.");
            }

            var paper = new Paper();
            var singles = service.GenerateSingleSelectionQuestions(singleCount).ToArray();
            var multiples = service.GenerateMultipleSelectionQuestions(multipleCount).ToArray();
            var subjectives = service.GenerateSubjectiveSelectionQuestions(subjectiveCount).ToArray();
            paper.SingleQuestions = _oasContext.SelectableQuestions.Where(q => singles.Contains(q.QuestionId)).ToList();
            paper.MultipleQuestions = _oasContext.SelectableQuestions.Where(q => multiples.Contains(q.QuestionId)).ToList();
            paper.SubjectiveQuestions = _oasContext.SubjectiveQuestions.Where(q => subjectives.Contains(q.QuestionId)).ToList();

            return paper;
        }
    }
}