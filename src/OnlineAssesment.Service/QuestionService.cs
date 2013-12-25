using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Service
{
    public class QuestionService : IQuestionService
    {
        public IEnumerable<Question> GetAllQuestion(Domain.CourseLevel courseLevel, QuestionType? questionType = null) {
            return Enumerable.Empty<Question>();
        }

        public Guid AddQuestion(Question question) {
            throw new NotImplementedException();
        }

        public void ModifyQuestion(Question question) {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid questionId) {
            throw new NotImplementedException();
        }
    }
}
