using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAssesment.Domain;

namespace OnlineAssesment.Service
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestion(Guid subjectId, QuestionType? questionType = null);
        Guid AddQuestion(Question question);
        void ModifyQuestion(Question question);
        void DeleteQuestion(Guid questionId);
    }
}
