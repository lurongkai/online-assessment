using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oas.Domain.Repository;

namespace Oas.Infrastructure.Repository
{
    public class QuestionService : IQuestionService
    {
        private OasContext _oasContext;
        public QuestionService(OasContext oasContext) {
            _oasContext = oasContext;
        }

        public IEnumerable<Domain.SelectableQuestion> GetCourseSubjectSelectableQuestions(string courseId, Guid subjectId) {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.SubjectiveQuestion> GetCourseSubjectSubjectiveQuestions(string courseId, Guid subjectId) {
            throw new NotImplementedException();
        }

        public void AddQuestionToCourseSubject(string courseId, Guid subjectId, Domain.Question question) {
            throw new NotImplementedException();
        }
    }
}
