using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAssesment.Service
{
    public class AnsweringService : IAnsweringService
    {
        public int UploadAnswerSheet(Domain.AnswerSheet answerSheet) {
            throw new NotImplementedException();
        }

        public IList<Domain.AnswerSheetItem> GetAllUnevaluatedAnswers(int examinationId) {
            throw new NotImplementedException();
        }

        public void EvaluatingAnswer(int answerId, int score) {
            throw new NotImplementedException();
        }
    }
}
