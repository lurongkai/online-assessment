using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestion(string subjectKey, QuestionForm? questionType = null);
        Question GetQuestion(Guid questionId);
        Guid AddQuestion(string subjectKey, Question question);
        void ModifyQuestion(Question question);
        void DeleteQuestion(Guid questionId);
    }
}