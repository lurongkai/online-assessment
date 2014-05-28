using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public class AnsweringService : IAnsweringService
    {
        public Guid UploadAnswerSheet(Guid examinationId, AnswerSheet answerSheet)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.AnswerSheetItem> GetAllUnevaluatedAnswers(Guid examinationId)
        {
            throw new NotImplementedException();
        }

        public void EvaluatingAnswer(Guid answerId, int score)
        {
            throw new NotImplementedException();
        }
    }
}
