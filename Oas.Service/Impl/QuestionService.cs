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
        public IEnumerable<Domain.Question> GetAllQuestion(string courseId, Messages.PaginationData paginationData) {
            throw new NotImplementedException();
        }

        public Domain.Question GetQuestion(Guid questionId) {
            throw new NotImplementedException();
        }

        public Guid CreateQuestion(string courseId, Domain.Question question) {
            throw new NotImplementedException();
        }

        public void ModifyQuestion(Guid questionId, Domain.Question question) {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid questionId) {
            throw new NotImplementedException();
        }
    }
}
