using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestion(Guid subjectId, QuestionForm? questionType = null);
        Question GetQuestion(Guid questionId);
        Guid AddQuestion(Guid subjectId, Question question);
        void ModifyQuestion(Question question);
        void DeleteQuestion(Guid questionId);
    }
}