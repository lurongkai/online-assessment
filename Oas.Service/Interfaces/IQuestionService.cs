using System;
using System.Collections.Generic;
using Oas.Domain;
using Oas.Service.Messages;

namespace Oas.Service.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllSelectableQuestion(string courseId, Guid subjectId);
        IEnumerable<Question> GetAllSubjectiveQuestion(string courseId, Guid subjectId);
        Question GetQuestion(Guid questionId);

        Guid CreateSelectableQuestion(Guid subjectId, SelectableQuestion question);
        Guid CreateSubjectiveQuestion(Guid subjectId, SubjectiveQuestion question);

        void DeleteQuestion(Guid questionId);
    }
}