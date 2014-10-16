using System;
using System.Collections.Generic;
using Oas.Domain;
using Oas.Service.Messages;

namespace Oas.Service.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestion(string courseId, PaginationData paginationData);
        Question GetQuestion(Guid questionId);

        Guid CreateQuestion(string courseId, Question question);
        void ModifyQuestion(Guid questionId, Question question);
        void DeleteQuestion(Guid questionId);
    }
}