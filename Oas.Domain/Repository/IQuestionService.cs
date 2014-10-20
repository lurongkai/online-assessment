using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Domain.Repository
{
    public interface IQuestionService
    {
        IEnumerable<SelectableQuestion> GetCourseSubjectSelectableQuestions(string courseId, Guid subjectId);
        IEnumerable<SubjectiveQuestion> GetCourseSubjectSubjectiveQuestions(string courseId, Guid subjectId);

        void AddQuestionToCourseSubject(string courseId, Guid subjectId, Question question);
    }
}
