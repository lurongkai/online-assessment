using Oas.Infrastructure;
using Oas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Service.Impl
{
    public class QuestionService : IQuestionService
    {
        private OasContext _oasContext;
        public QuestionService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public IEnumerable<Domain.Question> GetAllSelectableQuestion(string courseId, Guid subjectId) {
            return _oasContext.SelectableQuestions.Where(q => q.Subject.SubjectId == subjectId);
        }

        public IEnumerable<Domain.Question> GetAllSubjectiveQuestion(string courseId, Guid subjectId) {
            return _oasContext.SubjectiveQuestions.Where(q => q.Subject.SubjectId == subjectId);
        }

        public Domain.Question GetQuestion(Guid questionId) {
            throw new NotImplementedException();
        }

        public Guid CreateSelectableQuestion(Guid subjectId, Domain.SelectableQuestion question) {
            var subject = _oasContext.Subjects.Find(subjectId);
            question.Subject = subject;
            question.BelongTo = subject.BelongTo;
            _oasContext.SelectableQuestions.Add(question);

            _oasContext.SaveChanges();
            return question.QuestionId;
        }

        public Guid CreateSubjectiveQuestion(Guid subjectId, Domain.SubjectiveQuestion question) {
            var subject = _oasContext.Subjects.Find(subjectId);
            question.Subject = subject;
            question.BelongTo = subject.BelongTo;
            _oasContext.SubjectiveQuestions.Add(question);

            _oasContext.SaveChanges();
            return question.QuestionId;
        }

        public void DeleteQuestion(Guid questionId) {
            var selectable = _oasContext.SelectableQuestions.FirstOrDefault(q => q.QuestionId == questionId);
            var subjective = _oasContext.SubjectiveQuestions.FirstOrDefault(q => q.QuestionId == questionId);

            if (selectable != null) { _oasContext.SelectableQuestions.Remove(selectable); }
            if (subjective != null) { _oasContext.SubjectiveQuestions.Remove(subjective); }

            _oasContext.SaveChanges();
        }
    }
}
