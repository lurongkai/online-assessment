using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Service
{
    public class QuestionService : IQuestionService
    {
        public IList<Domain.Question> GetAllQuestion(Domain.CourseLevel courseLevel, Domain.QuestionType? questionType) {
            throw new NotImplementedException();
        }

        public Guid AddQuestion(Domain.Question question) {
            throw new NotImplementedException();
        }

        public void ModifyQuestion(Domain.Question question) {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid questionId) {
            throw new NotImplementedException();
        }
    }
}
